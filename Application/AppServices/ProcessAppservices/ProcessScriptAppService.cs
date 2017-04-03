namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities.CreditInvestigation;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Loan;
    using Core.Entities.Process;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using Core.Interfaces.Repositories.LoanRepositories;
    using Newtonsoft.Json.Linq;
    using ViewModels.FinanceViewModels;
    using ViewModels.Loan.CreditViewModel;
    using ViewModels.OrganizationViewModels;

    public class ProcessScriptAppService
    {
        private readonly FinanceAppService financeAppService;
        private readonly DatagramAppService datagramAppService;
        private readonly ProcessAppService processAppService;
        private readonly IFinanceRepository financeRepository;
        private readonly ICreditContractRepository creditContractRepository;
        private readonly ILoanRepository loanRepository;
        private readonly IOrganizationRepository organizationRepository;

        public ProcessScriptAppService(
            FinanceAppService financeAppService,
            DatagramAppService datagramAppService,
            ProcessAppService processAppService,
            IFinanceRepository financeRepository,
            ICreditContractRepository creditContractRepository,
            ILoanRepository loanRepository,
            IOrganizationRepository organizationRepository)
        {
            this.financeAppService = financeAppService;
            this.datagramAppService = datagramAppService;
            this.processAppService = processAppService;
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
            var finance = GetData<FinanceApplyViewModel>("10DC5FCF-18A4-E611-80C5-507B9DE4A488");

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
            var financeAudit = GetData<FinanceAuidtViewModel>("12DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建融资审核
            financeAppService.EditFinanceAuidt(financeAudit);
        }

        /// <summary>
        /// 融资复审
        /// </summary>
        public void FinanceReaudit()
        {
            // 获取融资审核数据
            var financeAudit = GetData<FinanceAuidtViewModel>("12DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 修改融资审核
            financeAppService.EditFinanceAuidt(financeAudit);
        }

        /// <summary>
        /// 运营补充
        /// </summary>
        public void FinanceOperation()
        {
            // 获取数据
            var finance = GetData<OperationViewModel>("13DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            financeAppService.EditOperation(finance);
        }

        /// <summary>
        /// 客户补充
        /// </summary>
        public void FinanceCustomer()
        {
            // 获取数据
            var finance = GetData<OperationViewModel>("13DC5FCF-18A4-E611-80C5-507B9DE4A488");

            // 创建或修改
            financeAppService.EditOperation(finance);

            // 执行合同的生成
            ////string path = @"~\upload\PDF\";
            ////financeAppService.CreateLeaseInfoPdf(finance.FinanceId, path);
        }

        /// <summary>
        /// 总经理审批
        /// </summary>
        public void FinalApproval()
        {
            // 修改信审审核人
            ////financeAppService.SetApprover(Instance.RootKey.Value);
        }

        /// <summary>
        /// 融资 - 完成
        /// </summary>
        public void FinanceFinish()
        {
            // 获取融资实体
            var finance = financeRepository.Get(Instance.RootKey.Value);
        }

        /// <summary>
        /// 添加机构
        /// </summary>
        public void Organization()
        {
            var organizationViewModel = GetData<OrganizationViewModel>("5FDC5FCF-18A4-E611-80C5-507B9DE4A488");

            ////var organization = organizationAppService.Create(organizationViewModel);

            ////var processTempDataViewModel = new ProcessTempDataViewModel<Organization>()
            ////{
            ////    InstanceId = Instance.Id,
            ////    ObjData = organization
            ////};

            ////processTempDataService.Create(processTempDataViewModel);

            var organization = processAppService.CreateProcessData<OrganizationViewModel, Organization>(organizationViewModel, Instance.Id);

            // 设置流程实例关联的业务标识
            Instance.RootKey = organization.Id;

            Instance.Title = $"{organization.Property.InstitutionChName}";
        }

        /// <summary>
        /// 添加机构 - 完成
        /// </summary>
        public void OrganizationFinish()
        {
            // 提交修改
            var organization = processAppService.SubmitProcessData<Organization>(Instance.Id);

            // 报文追踪
            Trace(organization);
        }

        /// <summary>
        /// 贷款合同
        /// </summary>
        public void CreditContract()
        {
            var creditContractViewModel = GetData<CreditContractViewModel>("60DC5FCF-18A4-E611-80C5-507B9DE4A488");

            var creditContract = processAppService.CreateProcessData<CreditContractViewModel, CreditContract>(creditContractViewModel, Instance.Id);

            // 设置流程实例关联的业务标识
            Instance.RootKey = creditContract.Id;

            var organization = organizationRepository.Get(creditContract.OrganizationId);
            Instance.Title = $"{"机构名：" + organization.Property.InstitutionChName + " 贷款合同编号：" + creditContract.CreditContractCode}";
        }

        /// <summary>
        /// 贷款合同 - 签订
        /// </summary>
        public void CreditContractSigned()
        {
            // 提交修改
            var creditContract = processAppService.SubmitProcessData<CreditContract>(Instance.Id);

            // 报文追踪
            Trace(creditContract, describe: CreditContractChangeEnum.签订合同);
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
            var loanViewModel = GetData<ViewModels.Loan.LoanViewModels.LoanViewModel>("61DC5FCF-18A4-E611-80C5-507B9DE4A488");

            var loan = processAppService.CreateProcessData<ViewModels.Loan.LoanViewModels.LoanViewModel, Loan>(loanViewModel, Instance.Id);

            // 设置流程实例关联的业务标识
            Instance.RootKey = loan.Id;

            var creditContract = creditContractRepository.Get(loan.CreditId);

            Instance.Title = $"{"授信合同编号：" + creditContract.CreditContractCode + " 借据编号：" + loan.ContractNumber}";
        }

        /// <summary>
        /// 借据 - 完成
        /// </summary>
        public void LoanFinish()
        {
            // 提交修改
            var loan = processAppService.SubmitProcessData<Loan>(Instance.Id);

            // 报文追踪
            Trace(loan);
        }

        /// <summary>
        /// 还款
        /// </summary>
        public void Payment()
        {
            var paymentViewModel = GetData<ViewModels.Loan.LoanViewModels.PaymentViewModel>("62DC5FCF-18A4-E611-80C5-507B9DE4A488");

            var payments = processAppService.CreateProcessData<ViewModels.Loan.LoanViewModels.PaymentViewModel, IEnumerable<PaymentHistory>>(paymentViewModel, Instance.Id);

            // 设置流程实例关联的业务标识
            Instance.RootKey = paymentViewModel.LoanId;

            var loan = loanRepository.Get(paymentViewModel.LoanId);
            Instance.Title = $"{"借据编号：" + loan.ContractNumber + " 还款时间:" + paymentViewModel.Payments.Last().ActualDatePayment.ToString("yyyy-MM-dd")}";
        }

        /// <summary>
        /// 还款 - 完成
        /// </summary>
        public void PaymentFinish()
        {
            // 提交修改
            var payments = processAppService.SubmitProcessData<IEnumerable<PaymentHistory>>(Instance.Id);

            // 报文追踪
            Trace(payments);
        }

        /// <summary>
        /// 机构变更
        /// </summary>
        public void OrganizateChange()
        {
            var organizationChangeViewModel = GetData<OrganizationChangeViewModel>("63DC5FCF-18A4-E611-80C5-507B9DE4A488");

            processAppService.CreateProcessData<OrganizationChangeViewModel, object>(organizationChangeViewModel, Instance.Id);

            Instance.RootKey = organizationChangeViewModel.Id;
            Instance.Title = $"{organizationChangeViewModel.Name} 机构信息变更";
        }

        /// <summary>
        /// 机构变更完成
        /// </summary>
        public void OrganizateChangeFinish()
        {
            // 提交修改
            var organizationChange = processAppService.SubmitProcessData<OrganizationChangeViewModel>(Instance.Id);

            // 报文追踪
            Trace(organizationChange);
        }

        private T GetData<T>(string formId) where T : class, new() => Data[formId.ToLower()].ToObject<T>();

        /// <summary>
        /// 报文追踪
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="describe">描述</param>
        private void Trace<T>(T entity, CreditContractChangeEnum? describe = null)
        {
            if (entity is Organization)
            {
                var customer = entity as Organization;

                // 添加机构 —> 报文追踪
                datagramAppService.Trace(referenceId: customer.Id, traceType: TraceTypeEnum.添加机构, defaultName: "添加机构：" + customer.Property.InstitutionChName, specialDate: customer.CreatedDate, organizateName: customer.Property.InstitutionChName);
            }
            else if (entity is CreditContract && describe != null)
            {
                var creditContract = entity as CreditContract;

                creditContract.Organization = organizationRepository.Get(creditContract.OrganizationId);

                switch (describe)
                {
                    default:
                        break;

                    case CreditContractChangeEnum.签订合同:
                        // 授信合同 - 签订 —> 报文追踪
                        datagramAppService.Trace(referenceId: creditContract.Id, traceType: TraceTypeEnum.签订授信合同, defaultName: $"签订贷款合同：{creditContract.CreditContractCode}", specialDate: creditContract.EffectiveDate, organizateName: creditContract.Organization.Property.InstitutionChName);
                        break;

                    case CreditContractChangeEnum.有效期变更:
                        // 授信合同 - 合同有效期变更 —> 报文追踪
                        datagramAppService.Trace(referenceId: creditContract.Id, traceType: TraceTypeEnum.合同变更, defaultName: $"贷款合同：{creditContract.CreditContractCode}有效日期变更", specialDate: creditContract.EffectiveDate, organizateName: creditContract.Organization.Property.InstitutionChName);
                        break;

                    case CreditContractChangeEnum.金额发生变化:
                        // 授信合同 - 合同金额发生变化 —> 报文追踪
                        datagramAppService.Trace(referenceId: creditContract.Id, traceType: TraceTypeEnum.合同变更, defaultName: "贷款合同：" + creditContract.CreditContractCode + "授信额度变更", specialDate: creditContract.EffectiveDate, organizateName: creditContract.Organization.Property.InstitutionChName);
                        break;

                    case CreditContractChangeEnum.合同终止:
                        // 授信合同 - 终止 —> 报文追踪
                        datagramAppService.Trace(referenceId: creditContract.Id, traceType: TraceTypeEnum.终止合同, defaultName: "贷款合同：" + creditContract.CreditContractCode + "终止", specialDate: creditContract.EffectiveDate, organizateName: creditContract.Organization.Property.InstitutionChName);
                        break;
                }
            }
            else if (entity is Loan)
            {
                var loan = entity as Loan;
                var credit = creditContractRepository.Get(loan.CreditId);

                // 借据 放款 —> 报文追踪
                datagramAppService.Trace(referenceId: loan.Id, traceType: TraceTypeEnum.借款, defaultName: $"申请借据：{loan.ContractNumber}，贷款合同编号：{credit.CreditContractCode}", specialDate: loan.SpecialDate, organizateName: credit.Organization.Property.InstitutionChName);
            }
            else if (entity is IEnumerable<PaymentHistory>)
            {
                // 还款
                var payments = (entity as IEnumerable<PaymentHistory>).ToList();

                var loan = loanRepository.Get(payments.First().LoanId);

                var creditContract = creditContractRepository.Get(loan.CreditId);

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
                                datagramAppService.Trace(referenceId: trace.Key.Id, traceType: type, defaultName: $"借据：{loan.ContractNumber}还款，还款金额：{trace.Key.ActualPaymentPrincipal}", specialDate: trace.Key.ActualDatePayment, organizateName: creditContract.Organization.Property.InstitutionChName);
                                break;
                            case TraceTypeEnum.逾期:
                                // 逾期 —> 报文追踪
                                datagramAppService.Trace(referenceId: loan.Id, traceType: type, defaultName: $"借据：{loan.ContractNumber}五级分类调整", specialDate: trace.Key.ActualDatePayment, organizateName: creditContract.Organization.Property.InstitutionChName);
                                break;
                            case TraceTypeEnum.欠息:
                                // 欠息 —> 报文追踪
                                datagramAppService.Trace(referenceId: trace.Key.Id, traceType: type, defaultName: $"借据：{loan.ContractNumber}欠息", specialDate: trace.Key.ActualDatePayment, organizateName: creditContract.Organization.Property.InstitutionChName);
                                break;
                        }
                    }
                }
            }
            else if (entity is OrganizationChangeViewModel)
            {
                var item = entity as OrganizationChangeViewModel;

                // 机构信息变更 —> 报文追踪
                datagramAppService.Trace(referenceId: Instance.Id, traceType: TraceTypeEnum.机构变更, defaultName: $"机构变更：{item.Name}", specialDate: DateTime.Now, organizateName: item.Name);
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
        }
    }
}
