namespace Application.ViewModels.Loan.LoanViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Entities;
    using Core.Entities.Loan;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class LoanViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        public HiddenEnum Hidden { get; set; } = HiddenEnum.审核中;

        [Required]
        [Display(Name = "授信合同")]
        public Guid CreditId { get; set; }

        /// <summary>
        /// 借据金额
        /// </summary>
        [Required]
        [Display(Name = "借据金额")]
        [DataType(DataType.Currency)]
        public decimal Principle { get; set; }

        /// <summary>
        /// 借据余额
        /// </summary>
        [Display(Name = "借据余额")]
        public decimal Balance { get; private set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        [Required]
        [Display(Name = "放款日期")]
        [DataType(DataType.Date)]
        public DateTime SpecialDate { get; set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        [Required]
        [Display(Name = "到期日期")]
        [DataType(DataType.Date)]
        public DateTime MatureDate { get; set; }

        /// <summary>
        /// 借据编号
        /// </summary>
        [Required]
        [Display(Name = "借据编号")]
        public string ContractNumber { get; set; }

        /// <summary>
        /// 日利率
        /// </summary>
        [Required]
        [Display(Name = "日利率")]
        public decimal InterestRate { get; set; }

        /// <summary>
        /// 借据状态
        /// </summary>
        [Display(Name = "借据状态")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LoanStatusEnum Status { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FourCategoryAssetsClassificationEnum? FourCategoryAssetsClassification { get; set; }

        /// <summary>
        /// 贷款业务种类
        /// </summary>
        [Required]
        [Display(Name = "贷款业务种类")]
        public string LoanBusinessTypes { get; set; }

        /// <summary>
        /// 贷款形式
        /// </summary>
        [Required]
        [Display(Name = "贷款形式")]
        public string LoanForm { get; set; }

        /// <summary>
        /// 贷款性质
        /// </summary>
        [Required]
        [Display(Name = "贷款性质")]
        public string LoanNature { get; set; }

        /// <summary>
        /// 贷款投向
        /// </summary>
        [Required]
        [Display(Name = "贷款投向")]
        public string LoansTo { get; set; }

        /// <summary>
        /// 贷款种类
        /// </summary>
        [Required]
        [Display(Name = "贷款种类")]
        public string LoanTypes { get; set; }

        /// <summary>
        /// 授信合同编号
        /// </summary>
        [Display(Name = "授信合同编号")]
        public string CreditContractCode { get; set; }

        [Display(Name = "机构名称")]
        public string OrganizateName { get; set; }

        /// <summary>
        /// 还款记录
        /// </summary>
        [Display(Name = "还款记录")]
        public IEnumerable<PaymentHistoryViewModel> Payments { get; set; }
    }
}
