namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities.CreditInvestigation;
    using Core.Entities.Flow;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using Newtonsoft.Json.Linq;
    using ViewModels.FinanceViewModels;
    using ViewModels.Loan.CreditViewModel;
    using ViewModels.OrganizationViewModels;

    public class FinanceScriptAppService
    {
        private readonly FinanceAppService financeAppService;
        private readonly LoanAppService loanAppService;
        private readonly OrganizationAppService organizationAppService;
        private readonly CreditContractAppService creditContractAppService;
        private readonly DatagramAppService datagramAppService;
        private readonly IFinanceRepository financeRepository;
        private readonly ICreditContractRepository creditContractRepository;
        private readonly ILoanRepository loanRepository;
        private readonly IOrganizationRepository organizationRepository;

        public FinanceScriptAppService(
            FinanceAppService financeAppService,
            OrganizationAppService organizationAppService,
            LoanAppService loanAppService,
            CreditContractAppService creditContractAppService,
            DatagramAppService datagramAppService,
            IFinanceRepository financeRepository,
            ICreditContractRepository creditContractRepository,
            ILoanRepository loanRepository,
            IOrganizationRepository organizationRepository)
        {
            this.financeAppService = financeAppService;
            this.organizationAppService = organizationAppService;
            this.loanAppService = loanAppService;
            this.creditContractAppService = creditContractAppService;
            this.datagramAppService = datagramAppService;
            this.financeRepository = financeRepository;
            this.creditContractRepository = creditContractRepository;
            this.loanRepository = loanRepository;
            this.organizationRepository = organizationRepository;
        }

        private enum CreditContractChangeEnum
        {
            签订合同 = 0,
            有效期变更 = 1,
            金额发生变化 = 2,
            合同终止 = 3
        }

        public Instance Instance { get; set; }

        public JObject Data { get; set; }

        /// <summary>
        /// 融资申请
        /// </summary>
        public void FinanceApply()
        {
            // 获取数据
            var finance = GetData<FinanceApplyViewModel>("57DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            if (finance.Id.HasValue)
            {
                financeAppService.Modify(finance);
            }
            else
            {
                financeAppService.Create(finance);

                // 设置流程实例关联的业务标识
                Instance.RootKey = finance.Id;
            }

            Instance.Title = $"{finance.Applicant.First(m => m.Type == ApplicationViewModel.TypeEnum.主要申请人).Name} - {finance.Vehicle.PlateNo}";
        }

        /// <summary>
        /// 融资审核
        /// </summary>
        public void FinanceAudit()
        {
            // 获取融资审核数据
            var financeAudit = GetData<FinanceAuidtViewModel>("58DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建融资审核
            financeAppService.EditFinanceAuidt(financeAudit);

            // 获取信审数据
            var financeCreditExmine = GetData<CreditExamineViewModel>("59DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建信审
            financeAppService.EditCreditExamine(financeCreditExmine);

            // 修改信审审核人
            financeAppService.SetApprover(financeAudit.FinanceId);
        }

        /// <summary>
        /// 融资复审
        /// </summary>
        public void FinanceReaudit()
        {
            // 获取融资审核数据
            var financeAudit = GetData<FinanceAuidtViewModel>("58DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 修改融资审核
            financeAppService.EditFinanceAuidt(financeAudit);

            // 修改信审审核人
            financeAppService.SetApprover(financeAudit.FinanceId);
        }

        /// <summary>
        /// 运营补充
        /// </summary>
        public void FinanceOperation()
        {
            // 获取数据
            var finance = GetData<OperationViewModel>("5ADC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            financeAppService.EditOperation(finance);
        }

        /// <summary>
        /// 客户补充
        /// </summary>
        public void FinanceCustomer()
        {
            // 获取数据
            var finance = GetData<OperationViewModel>("5ADC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            financeAppService.EditOperation(finance);

            // 执行合同的生成
            string path = @"~\upload\PDF\";
            financeAppService.CreateLeaseInfoPdf(finance.FinanceId, path);
        }

        /// <summary>
        /// 总经理审批
        /// </summary>
        public void FinalApproval()
        {
            // 修改信审审核人
            financeAppService.SetApprover(Instance.RootKey.Value);
        }

        /// <summary>
        /// 融资 - 完成
        /// </summary>
        public void FinanceFinish()
        {
            // 获取融资实体
            var finance = financeRepository.Get(Instance.RootKey.Value);

            // 设置Hidden为false
            SetHidden(finance);
        }

        /// <summary>
        /// 添加机构
        /// </summary>
        public void Organization()
        {
            var org = GetData<OrganizationViewModel>("5FDC5FCF-18A4-E611-80C5-507B9DE4A488");

            organizationAppService.Create(org);

            // 设置流程实例关联的业务标识
            Instance.RootKey = org.Base.Id;

            Instance.Title = $"{org.Property.InstitutionChName}";
        }

        /// <summary>
        /// 添加机构 - 审批通过
        /// </summary>
        public void OrganizationFinish()
        {
            // 获取机构实体
            var organization = organizationRepository.Get(Instance.RootKey.Value);

            // 报文追踪
            Trace(organization);

            // 设置Hidden为false
            SetHidden(organization);
        }

        /// <summary>
        /// 授信合同
        /// </summary>
        public void CreditContract()
        {
            var creditContract = GetData<CreditContractViewModel>("60DC5FCF-18A4-E611-80C5-507B9DE4A488");

            creditContractAppService.Create(creditContract);

            // 设置流程实例关联的业务标识
            Instance.RootKey = creditContract.Id;
            var organization = organizationRepository.Get(creditContract.OrganizationId);
            Instance.Title = $"{"机构名：" + organization.Property.InstitutionChName + " 授信合同编号：" + creditContract.CreditContractCode}";
        }

        /// <summary>
        /// 授信合同 - 签订
        /// </summary>
        public void CreditContractSigned()
        {
            CreditContractFinish(describe: CreditContractChangeEnum.签订合同);
        }

        /// <summary>
        /// 授信合同 - 有效期变更
        /// </summary>
        public void CreditContractEffectiveDate()
        {
            CreditContractFinish(describe: CreditContractChangeEnum.有效期变更);
        }

        /// <summary>
        /// 授信合同 - 金额发生变化
        /// </summary>
        public void CreditContractMoney()
        {
            CreditContractFinish(describe: CreditContractChangeEnum.金额发生变化);
        }

        /// <summary>
        /// 授信合同 - 合同终止
        /// </summary>
        public void CreditContractTerminate()
        {
            CreditContractFinish(describe: CreditContractChangeEnum.合同终止);
        }

        /// <summary>
        /// 借据
        /// </summary>
        public void Loan()
        {
            var loan = GetData<ViewModels.Loan.LoanViewModels.LoanViewModel>("61DC5FCF-18A4-E611-80C5-507B9DE4A488");

            loanAppService.ApplyLoan(loan);

            // 设置流程实例关联的业务标识
            Instance.RootKey = loan.Id;
            var credit = creditContractAppService.Get(loan.CreditId);
            Instance.Title = $"{"授信合同编号：" + credit.CreditContractCode + " 借据编号：" + loan.ContractNumber}";
        }

        /// <summary>
        /// 借据 - 放款
        /// </summary>
        public void LoanFinish()
        {
            // 获取借据实体
            var loan = loanRepository.Get(Instance.RootKey.Value);

            // 报文追踪
            Trace(loan);

            // 设置Hidden为false
            SetHidden(loan);
        }

        public void Payment()
        {
            var payment = GetData<ViewModels.Loan.LoanViewModels.PaymentViewModel>("62DC5FCF-18A4-E611-80C5-507B9DE4A488");

            loanAppService.Payment(payment);

            // 设置流程实例关联的业务标识
            Instance.RootKey = payment.LoanId;
            var loan = loanAppService.Get(payment.LoanId);
            Instance.Title = $"{"借据编号：" + loan.ContractNumber + " 还款时间:" + DateTime.Now.ToString("yyyy-MM-dd")}";
        }

        /// <summary>
        /// 还款记录 - 还款
        /// </summary>
        public void PaymentFinish()
        {
            // 获取借据实体
            var loan = loanRepository.Get(Instance.RootKey.Value);

            if (loan.Payments.Where(m => m.Hidden).Count() == 0)
            {
                throw new ArgumentNullException(nameof(loan.Payments), "错误流程，未新增还款记录");
            }

            // 报文追踪
            Trace(loan.Payments);

            // 设置Hidden为false
            loan.Payments.Where(m => m.Hidden).ToList().ForEach(payment =>
            {
                SetHidden(payment);
            });
        }

        /// <summary>
        /// 机构变更
        /// </summary>
        public void OrganizateChange()
        {
            // "64DC5FCF-18A4-E611-80C5-507B9DE4A488"
        }

        /// <summary>
        /// 机构变更完成
        /// </summary>
        public void OrganizateChangeFinish()
        {

        }

        private T GetData<T>(string formId) where T : class, new()
        {
            return Data[formId.ToLower()].ToObject<T>();
        }

        /// <summary>
        /// 报文追踪
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="describe">描述</param>
        private void Trace<T>(T entity, CreditContractChangeEnum? describe = null)
        {
            if (entity is Core.Entities.Customers.Enterprise.Organization)
            {
                var customer = entity as Core.Entities.Customers.Enterprise.Organization;

                // 添加机构 —> 报文追踪
                datagramAppService.Trace(referenceId: customer.Id, traceType: TraceTypeEnum.添加机构, defaultName: "添加机构：" + customer.Property.InstitutionChName, specialDate: customer.CreatedDate);
            }
            else if (entity is CreditContract && describe != null)
            {
                var credit = entity as CreditContract;

                switch (describe)
                {
                    default:
                        break;

                    case CreditContractChangeEnum.签订合同:
                        // 授信合同 - 签订 —> 报文追踪
                        datagramAppService.Trace(referenceId: credit.Id, traceType: TraceTypeEnum.签订授信合同, defaultName: $"签订贷款合同：{credit.CreditContractCode}", specialDate: credit.EffectiveDate);
                        break;

                    case CreditContractChangeEnum.有效期变更:
                        // 授信合同 - 合同有效期变更 —> 报文追踪
                        datagramAppService.Trace(referenceId: credit.Id, traceType: TraceTypeEnum.合同变更, defaultName: $"贷款合同：{credit.CreditContractCode}有效日期变更", specialDate: credit.EffectiveDate);
                        break;

                    case CreditContractChangeEnum.金额发生变化:
                        // 授信合同 - 合同金额发生变化 —> 报文追踪
                        datagramAppService.Trace(referenceId: credit.Id, traceType: TraceTypeEnum.合同变更, defaultName: "贷款合同：" + credit.CreditContractCode + "授信额度变更", specialDate: credit.EffectiveDate);
                        break;

                    case CreditContractChangeEnum.合同终止:
                        // 授信合同 - 终止 —> 报文追踪
                        datagramAppService.Trace(referenceId: credit.Id, traceType: TraceTypeEnum.终止合同, defaultName: "贷款合同：" + credit.CreditContractCode + "终止", specialDate: credit.EffectiveDate);
                        break;
                }
            }
            else if (entity is Loan)
            {
                var loan = entity as Loan;
                var credit = creditContractRepository.Get(loan.CreditId);
                
                // 借据 放款 —> 报文追踪
                datagramAppService.Trace(referenceId: loan.Id, traceType: TraceTypeEnum.借款, defaultName: $"申请借据：{loan.ContractNumber}，贷款合同编号：{credit.CreditContractCode}", specialDate: loan.SpecialDate);
            }
            else if (entity is IEnumerable<PaymentHistory>)
            {
                // 还款
                var payments = (entity as IEnumerable<PaymentHistory>).Where(m => m.Hidden).ToList();

                var loan = loanRepository.Get(payments.First().LoanId);

                var traces = new Dictionary<PaymentHistory, ICollection<TraceTypeEnum>>();

                foreach (var payment in payments)
                {
                    var traceTypes = new List<TraceTypeEnum>();

                    if (payment.ActualPaymentPrincipal > 0)
                    {
                        traceTypes.Add(TraceTypeEnum.还款);
                    }

                    if (payment.ScheduledPaymentPrincipal > payment.ActualPaymentPrincipal)
                    {
                        traceTypes.Add(TraceTypeEnum.逾期);
                    }

                    if (payment.ScheduledPaymentInterest > payment.ActualPaymentInterest)
                    {
                        traceTypes.Add(TraceTypeEnum.欠息);
                    }

                    traces.Add(payment, traceTypes);
                }

                foreach (var trace in traces)
                {
                    foreach (var type in trace.Value)
                    {
                        switch (type)
                        {
                            default:
                                break;
                            case TraceTypeEnum.还款:
                                // 还款 —> 报文追踪
                                datagramAppService.Trace(referenceId: trace.Key.Id, traceType: type, defaultName: $"借据：{loan.ContractNumber}还款，还款金额：{trace.Key.ActualPaymentPrincipal}", specialDate: trace.Key.ActualDatePayment);
                                break;
                            case TraceTypeEnum.逾期:
                                // 逾期 —> 报文追踪
                                datagramAppService.Trace(referenceId: loan.Id, traceType: type, defaultName: $"借据：{loan.ContractNumber}五级分类调整", specialDate: trace.Key.ActualDatePayment);
                                break;
                            case TraceTypeEnum.欠息:
                                // 欠息 —> 报文追踪
                                datagramAppService.Trace(referenceId: trace.Key.Id, traceType: type, defaultName: $"借据：{loan.ContractNumber}欠息", specialDate: trace.Key.ActualDatePayment);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置Hidden为false
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">实体</param>
        private void SetHidden<T>(T entity)
        {
            if (entity is Core.Interfaces.IProcessable)
            {
                (entity as Core.Interfaces.IProcessable).Hidden = false;
            }
        }

        /// <summary>
        /// 授信合同 - 审批通过
        /// </summary>
        /// <param name="describe">描述</param>
        private void CreditContractFinish(CreditContractChangeEnum describe)
        {
            // 获取授信合同实体
            var creditContract = creditContractRepository.Get(Instance.RootKey.Value);

            // 报文追踪
            Trace(creditContract, describe: describe);

            // 设置Hidden为false
            SetHidden(creditContract);
        }
    }
}
