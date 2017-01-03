namespace Application
{
    using System.Linq;
    using Core.Entities.Flow;
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

        public FinanceScriptAppService(FinanceAppService financeAppService,OrganizationAppService organizationAppService,LoanAppService loanAppService,CreditContractAppService creditContractAppService)
        {
            this.financeAppService = financeAppService;
            this.organizationAppService = organizationAppService;
            this.loanAppService = loanAppService;
            this.creditContractAppService = creditContractAppService;
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
        /// 添加机构
        /// </summary>
        public void Organization()
        {
            var org = GetData<OrganizationViewModel>("5EDC5FCF-18A4-E611-80C5-507B9DE4A488");

            organizationAppService.Create(org);
        }

        /// <summary>
        /// 授信合同
        /// </summary>
        public void CreditContract()
        {
            var creditContract = GetData<CreditContractViewModel>("5FDC5FCF-18A4-E611-80C5-507B9DE4A488");

            creditContractAppService.Create(creditContract);
        }

        /// <summary>
        /// 借据
        /// </summary>
        public void Loan()
        {
            var loan = GetData<ViewModels.Loan.LoanViewModels.LoanViewModel>("60DC5FCF-18A4-E611-80C5-507B9DE4A488");

            loanAppService.ApplyLoan(loan);
        }

        private T GetData<T>(string formId) where T : class, new()
        {
            return Data[formId.ToLower()].ToObject<T>();
        }
    }
}
