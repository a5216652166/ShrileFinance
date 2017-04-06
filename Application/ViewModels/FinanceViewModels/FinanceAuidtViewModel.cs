namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;

    /// <summary>
    /// 融资审核
    /// </summary>
    public class FinanceAuidtViewModel
    {
        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid FinanceId { get; set; }

        /// <summary>
        /// 融资项
        /// </summary>
        public virtual IEnumerable<FinanceItemViewModel> FinancialItem { get; set; }

        /// <summary>
        /// 厂商指导价
        /// </summary>
        public decimal? ManufacturerGuidePrice { get; set; }

        /// <summary>
        /// 车辆指导价(下限)
        /// </summary>
        public string VehicleSalePriseMin { get; set; }

        /// <summary>
        /// 车辆指导价(上限)
        /// </summary>
        public string VehicleSalePriseMax { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? Margin { get; set; }

        /// <summary>
        /// 审批融资金额
        /// </summary>
        public decimal? ApprovalMoney { get; set; }

        /// <summary>
        /// 月供额度
        /// </summary>
        public decimal? Payment { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal? Poundage { get; set; }

        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal SelfPrincipal { get; set; }

        /// <summary>
        /// 产品利率
        /// </summary>
        public decimal ProduceRateMonth { get; set; }

        /// <summary>
        /// 产品期限
        /// </summary>
        public int ProducePeriods { get; set; }

        /// <summary>
        /// 是否为复审
        /// </summary>
        public bool IsReview { get; set; }
    }
}
