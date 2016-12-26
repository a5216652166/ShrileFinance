namespace Core.Entities.Customers.Enterprise
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 财务报表基本信息
    /// </summary>
    public class FinancialAffairs : Entity
    {
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
        public virtual ICollection<CashFlow> CashFlow { get; set; }

        /// <summary>
        /// 资产负债
        /// </summary>
        public virtual ICollection<Liabilities> Liabilities { get; set; }

        /// <summary>
        /// 利润利润分配
        /// </summary>
        public virtual ICollection<Profit> Profit { get; set; }

        /// <summary>
        /// 事业单位收入支出
        /// </summary>
        public virtual ICollection<InstitutionIncomeExpenditure> IncomeExpenditur { get; set; }

        /// <summary>
        /// 事业单位资产负债
        /// </summary>
        public virtual ICollection<InstitutionLiabilities> InstitutionLiabilities { get; set; }
    }
}
