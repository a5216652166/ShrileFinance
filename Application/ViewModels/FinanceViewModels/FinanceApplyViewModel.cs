namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using AccountViewModels;
    using Application.Produce.ProduceViewModels;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using Application.ViewModels.PartnerViewModels;

    public class FinanceApplyViewModel : IEntityViewModel
    {
        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// 厂商指导价
        /// </summary>
        public decimal ManufacturerGuidePrice { get; set; }

        /// <summary>
        /// 融资本金
        /// </summary>
        public decimal Principal { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime? DateEffective { get; set; }

        /// <summary>
        /// 融资金额
        /// </summary>
        public decimal? Financing { get; set; }

        /// <summary>
        /// 月供先付期数
        /// </summary>
        public int? OncePayMonths { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public UserViewModel CreateBy { get; set; }

        /// <summary>
        /// 合作商
        /// </summary>
        public PartnerViewModel CreateOf { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual IEnumerable<ApplicationViewModel> Applicant { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        public virtual VehicleViewModel.VehicleViewModel Vehicle { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public virtual IEnumerable<ContractViewModel> Contact { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual ProduceViewModel Produce { get; set; }

        /// <summary>
        /// 融资产品项
        /// </summary>
        public virtual IEnumerable<FinancialItemViewModel> FinancialItem { get; set; }
    }
}
