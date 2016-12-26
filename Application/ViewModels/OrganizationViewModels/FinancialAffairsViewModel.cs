namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.Collections.Generic;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 财务
    /// </summary>
    public class FinancialAffairsViewModel
    {
        public FinancialAffairsViewModel()
        {
            CashFlow = new HashSet<CashFlowViewModel>();
            Liabilities = new HashSet<LiabilitiesViewModel>();
            Profit = new HashSet<ProfitViewModel>();
            IncomeExpenditur = new HashSet<InstitutionIncomeExpenditureViewModel>();
            InstitutionLiabilities = new HashSet<InstitutionLiabilitiesViewModel>();
        }

        /// <summary>
        /// 报表年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 报表类型细分
        /// </summary>
        public int TypeSubdivision { get; set; }

        /// <summary>
        /// 审计事务所
        /// </summary>
        public string AuditFirm { get; set; }

        /// <summary>
        /// 审计人员名称
        /// </summary>
        public string AuditorName { get; set; }

        /// <summary>
        /// 审计日期
        /// </summary>
        public DateTime? AuditorDate { get; set; }

        /// <summary>
        /// 现金流量
        /// </summary>
        public IEnumerable<CashFlowViewModel> CashFlow { get; set; }

        /// <summary>
        /// 资产负债
        /// </summary>
        public IEnumerable<LiabilitiesViewModel> Liabilities { get; set; }

        /// <summary>
        /// 利润利润分配
        /// </summary>
        public IEnumerable<ProfitViewModel> Profit { get; set; }

        /// <summary>
        /// 事业单位收入支出
        /// </summary>
        public IEnumerable<InstitutionIncomeExpenditureViewModel> IncomeExpenditur { get; set; }

        /// <summary>
        /// 事业单位资产负债
        /// </summary>
        public IEnumerable<InstitutionLiabilitiesViewModel> InstitutionLiabilities { get; set; }
    }
}
