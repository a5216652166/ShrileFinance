namespace Core.Services.CreditInvestigation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.CreditInvestigation;
    using Entities.CreditInvestigation.Datagram;
    using Entities.CreditInvestigation.DatagramFile;
    using Entities.CreditInvestigation.Record.LoanRecords;
    using Entities.CreditInvestigation.Record.OrganizationRecords;
    using Entities.Loan;
    using Exceptions;
    using Interfaces.Repositories;

    public class DatagramFactoryService
    {
        private readonly IProcessTempDataRepository processTempDataRepository;
        private readonly IDatagramFileRepository datagramFileRepository;
        private readonly IOrganizationRepository organizationRepository;
        private readonly ICreditContractRepository creditRepository;
        private readonly ILoanRepository loanRepository;
        private readonly IPaymentHistoryRepository paymentRepository;

        public DatagramFactoryService(
            IProcessTempDataRepository processTempDataRepository,
            IDatagramFileRepository datagramFileRepository,
            IOrganizationRepository organizationRepository,
            ICreditContractRepository creditRepository,
            ILoanRepository loanRepository,
            IPaymentHistoryRepository paymentRepository)
        {
            this.processTempDataRepository = processTempDataRepository;
            this.datagramFileRepository = datagramFileRepository;
            this.organizationRepository = organizationRepository;
            this.creditRepository = creditRepository;
            this.loanRepository = loanRepository;
            this.paymentRepository = paymentRepository;
        }

        /// <summary>
        /// 生成报文
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        public IEnumerable<DatagramFile> Generate(Trace trace)
        {
            var datagramFiles = new List<DatagramFile>();

            switch (trace.Type)
            {
                case TraceTypeEnum.添加机构:
                    datagramFiles.Add(
                        CreateOrganization(trace));
                    datagramFiles.Add(
                        CreateBorrower(trace));
                    break;
                case TraceTypeEnum.签订授信合同:
                    datagramFiles.Add(
                         CreateContract(trace));
                    break;
                case TraceTypeEnum.借款:
                    datagramFiles.Add(
                        CreateLoan(trace));
                    break;
                case TraceTypeEnum.还款:
                    datagramFiles.Add(
                        CreatePayment(trace));
                    break;
                case TraceTypeEnum.终止合同:
                    datagramFiles.Add(
                        StopContract(trace));
                    break;
                case TraceTypeEnum.逾期:
                    datagramFiles.Add(
                        AdjustLoan(trace));
                    break;
                case TraceTypeEnum.合同变更:
                    datagramFiles.Add(
                        ModifyContract(trace));
                    break;
                case TraceTypeEnum.欠息:
                    datagramFiles.Add(
                        DebitInterest(trace));
                    break;
                case TraceTypeEnum.机构变更:
                    datagramFiles.Add(
                        ModifyOrganization(trace));
                    datagramFiles.Add(
                        CreateBorrower(trace));
                    break;
                default:
                    throw new ArgumentOutOfRangeAppException(nameof(trace.Type), "不支持的跟踪操作类型。");
            }

            datagramFiles.ForEach(item =>
            {
                item.TraceId = trace.Id;
                item.SerialNumber = datagramFileRepository.AllotSerialNumber(item);
            });

            return datagramFiles;
        }

        /// <summary>
        /// 创建机构
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile CreateOrganization(Trace trace)
        {
            var organization = organizationRepository.Get(trace.ReferenceId);

            var datagramFile = OrganizationDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.机构基本信息报文)
                .AddRecord(new OrganizationBaseRecord(organization));

            var familyDatagram = datagramFile.GetDatagram(DatagramTypeEnum.家族成员信息报文);
            organization.Managers.ToList().ForEach(m => m.FamilyMembers
                .ForEach(n => familyDatagram.AddRecord(new FamilyMemberRecord(m, n))));
            organization.Shareholders.ToList().ForEach(m => m.FamilyMembers
                .ForEach(n => familyDatagram.AddRecord(new FamilyMemberRecord(m, n))));

            return datagramFile;
        }

        /// <summary>
        /// 创建借款人
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile CreateBorrower(Trace trace)
        {
            var organization = organizationRepository.Get(trace.ReferenceId);

            if (organization == null)
            {
                var processTempData = processTempDataRepository.GetByInstanceId(trace.ReferenceId);
                organization = organizationRepository.Get(processTempData.Instance.RootKey.Value);
            }

            var datagramFile = BorrowerDatagramFile.Create();

            var financialDatagram = datagramFile.GetDatagram(DatagramTypeEnum.财务报表信息采集报文);
            if (organization.FinancialAffairs != null)
            {
                foreach (var item in organization.FinancialAffairs.Liabilities)
                {
                    financialDatagram.AddRecord(new BalanceSheetRecord(organization, item));
                }

                foreach (var item in organization.FinancialAffairs.Profit)
                {
                    financialDatagram.AddRecord(new ProfitRecord(organization, item));
                }

                foreach (var item in organization.FinancialAffairs.CashFlow)
                {
                    financialDatagram.AddRecord(new CashFlowRecord(organization, item));
                }

                foreach (var item in organization.FinancialAffairs.InstitutionLiabilities)
                {
                    financialDatagram.AddRecord(new InstitutionLiabilitiesRecord(organization, item));
                }

                foreach (var item in organization.FinancialAffairs.IncomeExpenditur)
                {
                    financialDatagram.AddRecord(new InstitutionIncomeExpenditureRecord(organization, item));
                }
            }

            var concern = datagramFile.GetDatagram(DatagramTypeEnum.关注信息采集报文);

            if (organization.BigEvent.Count != 0)
            {
                concern.AddRecord(new BigEventRecord(organization));
            }

            if (organization.Litigation.Count != 0)
            {
                concern.AddRecord(new LitigationRecord(organization));
            }

            return datagramFile;
        }

        /// <summary>
        /// 签订合同
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile CreateContract(Trace trace)
        {
            var credit = creditRepository.Get(trace.ReferenceId);

            var datagramFile = LoanDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanContractInfoRecord(credit, credit.EffectiveDate));
            var guarantyDatagram = datagramFile.GetDatagram(DatagramTypeEnum.担保业务信息采集报文);

            foreach (var item in credit.GuarantyContract)
            {
                if (item.Guarantor is GuarantorOrganization)
                {
                    if (item is GuarantyContractPledge)
                    {
                        guarantyDatagram.AddRecord(new PledgeContractInfoRecord(credit, (GuarantyContractPledge)item));
                    }
                    else if (item is GuarantyContractMortgage)
                    {
                        guarantyDatagram.AddRecord(new MortgageContractInfoRecord(credit, (GuarantyContractMortgage)item));
                    }
                    else
                    {
                        guarantyDatagram.AddRecord(new EnsureContractInfoRecord(credit, (GuarantyContract)item));
                    }
                }
                else if (item.Guarantor is GuarantorPerson)
                {
                    if (item is GuarantyContractPledge)
                    {
                        guarantyDatagram.AddRecord(new NaturalPledgeContractInfoRecord(credit, (GuarantyContractPledge)item));
                    }
                    else if (item is GuarantyContractMortgage)
                    {
                        guarantyDatagram.AddRecord(new NaturalMortgageContractInfoRecord(credit, (GuarantyContractMortgage)item));
                    }
                    else
                    {
                        guarantyDatagram.AddRecord(new NaturalEnsureContractInfoRecord(credit, (GuarantyContract)item));
                    }
                }
            }

            return datagramFile;
        }

        /// <summary>
        /// 合同关键数据项发生变化
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile ModifyContract(Trace trace)
        {
            var credit = creditRepository.Get(trace.ReferenceId);

            var datagramFile = LoanDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanContractInfoRecord(credit, DateTime.Now));

            return datagramFile;
        }

        /// <summary>
        /// 合同终止
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile StopContract(Trace trace)
        {
            var credit = creditRepository.Get(trace.ReferenceId);

            var datagramFile = LoanDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanContractInfoRecord(credit, credit.ExpirationDate));

            return datagramFile;
        }

        /// <summary>
        /// 放款
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile CreateLoan(Trace trace)
        {
            var loan = loanRepository.Get(trace.ReferenceId);
            var credit = creditRepository.Get(loan.CreditId);

            var datagramFile = LoanDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanContractInfoRecord(credit, loan.SpecialDate))
                .AddRecord(new LoanIousInfoRecord(loan, credit, loan.SpecialDate));

            return datagramFile;
        }

        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile CreatePayment(Trace trace)
        {
            var payment = paymentRepository.Get(trace.ReferenceId);
            var loan = loanRepository.Get(payment.LoanId);
            var credit = creditRepository.Get(loan.CreditId);

            var datagramFile = LoanDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanIousInfoRecord(loan, credit, payment.ActualDatePayment))
                .AddRecord(new LoanRepayInfoRecord(credit, loan, payment));

            return datagramFile;
        }

        /// <summary>
        /// 五级分类调整
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile AdjustLoan(Trace trace)
        {
            var loan = loanRepository.Get(trace.ReferenceId);
            var credit = creditRepository.Get(loan.CreditId);

            var datagramFile = LoanDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanIousInfoRecord(loan, credit, loan.SpecialDate));

            return datagramFile;
        }

        /// <summary>
        /// 欠息
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile DebitInterest(Trace trace)
        {
            var payment = paymentRepository.Get(trace.ReferenceId);
            var loan = loanRepository.Get(payment.LoanId);
            var credit = creditRepository.Get(loan.CreditId);

            var datagramFile = LoanDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.欠息信息采集报文)
                .AddRecord(new DebitInterestInfoRecord(credit, payment));

            return datagramFile;
        }

        /// <summary>
        /// 机构变更
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private DatagramFile ModifyOrganization(Trace trace)
        {
            var processTempData = processTempDataRepository.GetByInstanceId(trace.ReferenceId);

            // 获取机构实体
            var organization = organizationRepository.Get(processTempData.Instance.RootKey.Value);

            var datagramFile = OrganizationDatagramFile.Create();

            datagramFile.GetDatagram(DatagramTypeEnum.机构基本信息报文)
                .AddRecord(new OrganizationBaseRecord(organization));

            var familyDatagram = datagramFile.GetDatagram(DatagramTypeEnum.家族成员信息报文);
            organization.Managers.ToList().ForEach(m => m.FamilyMembers
                .ForEach(n => familyDatagram.AddRecord(new FamilyMemberRecord(m, n))));
            organization.Shareholders.ToList().ForEach(m => m.FamilyMembers
                .ForEach(n => familyDatagram.AddRecord(new FamilyMemberRecord(m, n))));

            return datagramFile;
        }
    }
}
