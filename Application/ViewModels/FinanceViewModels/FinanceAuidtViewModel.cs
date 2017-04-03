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
        public virtual IEnumerable<FinancialItemViewModel> FinancialItem { get; set; }

        /// <summary>
        /// 厂商指导价
        /// </summary>
        public decimal? ManufacturerGuidePrice { get; set; }

        /// <summary>
        /// 车辆指导价
        /// </summary>
        public string VehicleSalePrise { get; set; }

        /// <summary>
        /// 建议融资金额
        /// </summary>
        public decimal? AdviceMoney { get; set; }
       
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
        /// 是否为复审
        /// </summary>
        public bool IsReview { get; set; }
    }
}
