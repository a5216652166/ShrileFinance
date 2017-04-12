namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AccountViewModels;
    using Application.Produce.ProduceViewModels;
    using Application.ViewModels.FinanceViewModels.BranchOfficeViewModels;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using Application.ViewModels.PartnerViewModels;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using static Core.Entities.Finance.Finance;

    public class FinanceApplyViewModel : IEntityViewModel
    {
        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// 产品标识
        /// </summary>
        public Guid ProduceId { get; set; }

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
        /// 自付金额
        /// </summary>
        public decimal SelfPrincipal { get; set; }

        /// <summary>
        /// 子公司标识
        /// </summary>
        [Required(ErrorMessage ="子公司不可为空")]
        public Guid? BranchOfficeId { get; set; }

        /// <summary>
        /// 登记对象
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [Required(ErrorMessage = "登记对象不可为空")]
        public RegistrantEnum? Registrant { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Required(ErrorMessage = "电子邮箱不可为空")]
        public string Email { get; set; }

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
        public virtual IEnumerable<FinanceItemViewModel> FinanceItems { get; set; }
    }
}
