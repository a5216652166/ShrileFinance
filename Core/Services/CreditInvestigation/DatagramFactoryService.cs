namespace Core.Services.CreditInvestigation
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities.CreditInvestigation;
    using Entities.CreditInvestigation.Datagram;
    using Entities.CreditInvestigation.DatagramFile;
    using Entities.CreditInvestigation.Record.LoanRecords;
    using Entities.CreditInvestigation.Record.OrganizationRecords;
    using Entities.Customers.Enterprise;
    using Entities.Loan;
    using Exceptions;
    using Interfaces.Repositories;

    public class DatagramFactoryService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly ICreditContractRepository creditRepository;
        private readonly ILoanRepository loanRepository;
        private readonly IPaymentHistoryRepository paymentRepository;

        public DatagramFactoryService(
            IOrganizationRepository organizationRepository,
            ICreditContractRepository creditRepository,
            ILoanRepository loanRepository,
            IPaymentHistoryRepository paymentRepository)
        {
            this.organizationRepository = organizationRepository;
            this.creditRepository = creditRepository;
            this.loanRepository = loanRepository;
            this.paymentRepository = paymentRepository;
        }

        /// <summary>
        /// 生成报文
        /// </summary>
        /// <param name="traces">跟踪记录集合</param>
        public void Generate(IEnumerable<Trace> traces)
        {
            AbsDatagramFile datagramFile;

            foreach (var trace in traces)
            {
                switch (trace.Type)
                {
                    case TraceTypeEnum.添加机构:
                        datagramFile = CreateLoan(trace);
                        break;
                    case TraceTypeEnum.签订授信合同:
                        datagramFile = CreateLoan(trace);
                        break;
                    case TraceTypeEnum.借款:
                        datagramFile = CreateLoan(trace);
                        break;
                    case TraceTypeEnum.还款:
                        datagramFile = CreateLoan(trace);
                        break;
                    case TraceTypeEnum.终止合同:
                        datagramFile = CreateLoan(trace);
                        break;
                    case TraceTypeEnum.逾期:
                        datagramFile = CreateLoan(trace);
                        break;
                    case TraceTypeEnum.合同变更:
                        datagramFile = CreateLoan(trace);
                        break;
                    case TraceTypeEnum.欠息:
                        datagramFile = CreateLoan(trace);
                        break;
                    default:
                        throw new ArgumentOutOfRangeAppException(nameof(trace.Type), "不支持的跟踪操作类型。");
                }

                trace.AddDatagram(datagramFile);
            }
        }

        /// <summary>
        /// 创建机构
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private AbsDatagramFile CreateOrganization(Trace trace)
        {
            var organization = organizationRepository.Get(trace.ReferenceId);

            var datagramFile = new OrganizationDatagramFile(trace.SerialNumber);

            datagramFile.GetDatagram(DatagramTypeEnum.机构基本信息报文)
                .AddRecord(new OrganizationBaseRecord(organization));

            var familyDatagram = datagramFile.GetDatagram(DatagramTypeEnum.家族成员信息报文);
            organization.Managers.ToList().ForEach(m => m.FamilyMembers
                .ForEach(n => familyDatagram.AddRecord(new FamilyMemberRecord(m, n))));
            organization.Shareholders.ToList().ForEach(m => m.FamilyMembers
                .ForEach(n => familyDatagram.AddRecord(new FamilyMemberRecord(m, n))));

            var financialDatagram = datagramFile.GetDatagram(DatagramTypeEnum.财务报表信息采集报文);
            var financial = organization.FinancialAffairs;
            foreach (var item in financial.Liabilities)
            {
                financialDatagram.AddRecord(new BalanceSheetRecord(financial, item));
            }
            foreach (var item in financial.Profit)
            {
                financialDatagram.AddRecord(new ProfitRecord(financial, item));
            }
            foreach (var item in financial.CashFlow)
            {
                financialDatagram.AddRecord(new CashFlowRecord(financial, item));
            }
            foreach (var item in financial.InstitutionLiabilities)
            {
                financialDatagram.AddRecord(new InstitutionLiabilitiesRecord(financial, item));
            }
            foreach (var item in financial.IncomeExpenditur)
            {
                financialDatagram.AddRecord(new InstitutionIncomeExpenditureRecord(financial, item));
            }

            datagramFile.GetDatagram(DatagramTypeEnum.关注信息采集报文)
                .AddRecord(new BigEventRecord(organization))
                .AddRecord(new LitigationRecord(organization));

            return datagramFile;
        }

        /// <summary>
        /// 签订合同
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private AbsDatagramFile CreateContract(Trace trace)
        {
            var credit = creditRepository.Get(trace.ReferenceId);

            var datagramFile = new LoanDatagramFile(trace.SerialNumber);

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanContractInfoRecord(credit));
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
                        guarantyDatagram.AddRecord(new EnsureContractInfoRecord(credit, (GuarantyContractMortgage)item));
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
                        guarantyDatagram.AddRecord(new NaturalEnsureContractInfoRecord(credit, (GuarantyContractMortgage)item));
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
        private AbsDatagramFile ModifyContract(Trace trace)
        {
            var credit = creditRepository.Get(trace.ReferenceId);

            var datagramFile = new LoanDatagramFile(trace.SerialNumber);

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanContractInfoRecord(credit));

            return datagramFile;
        }

        /// <summary>
        /// 合同终止
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private AbsDatagramFile StopContract(Trace trace)
        {
            var credit = creditRepository.Get(trace.ReferenceId);

            var datagramFile = new LoanDatagramFile(trace.SerialNumber);

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanContractInfoRecord(credit));

            return datagramFile;
        }

        /// <summary>
        /// 放款
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private AbsDatagramFile CreateLoan(Trace trace)
        {
            var loan = loanRepository.Get(trace.ReferenceId);
            var credit = creditRepository.Get(loan.CreditId);

            var datagramFile = new LoanDatagramFile(trace.SerialNumber);

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanContractInfoRecord(credit))
                .AddRecord(new LoanIousInfoRecord(loan, credit));

            return datagramFile;
        }

        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private AbsDatagramFile CreatePayment(Trace trace)
        {
            var payment = paymentRepository.Get(trace.ReferenceId);
            var loan = loanRepository.Get(payment.LoanId);
            var credit = creditRepository.Get(loan.CreditId);

            var datagramFile = new LoanDatagramFile(trace.SerialNumber);

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanIousInfoRecord(loan, credit))
                .AddRecord(new LoanRepayInfoRecord(credit, payment));

            return datagramFile;
        }

        /// <summary>
        /// 五级分类调整
        /// </summary>
        /// <param name="trace">跟踪记录</param>
        /// <returns></returns>
        private AbsDatagramFile AdjustLoan(Trace trace)
        {
            var loan = loanRepository.Get(trace.ReferenceId);
            var credit = creditRepository.Get(loan.CreditId);

            var datagramFile = new LoanDatagramFile(trace.SerialNumber);

            datagramFile.GetDatagram(DatagramTypeEnum.贷款业务信息采集报文)
                .AddRecord(new LoanIousInfoRecord(loan, credit));

            return datagramFile;
        }
    }
}
