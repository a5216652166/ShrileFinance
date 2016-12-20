namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class StockholderSegment
    {
        public string 信息类别
        {
            get { return "G"; }
        }

        /// <summary>
        /// 股东类型
        /// </summary>
        [Display(Name = "股东类型"), StringLength(1), Required]
        public string ShareholdersType { get; set; }

        /// <summary>
        /// 股东名称
        /// </summary>
        [Display(Name = "股东名称"), StringLength(80), Required]
        public string ShareholdersName { get; set; }

        /// <summary>
        /// 证件类型/登记注册号类型
        /// </summary>
        [Display(Name = "证件类型/登记注册号类型"), StringLength(2)]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 证件号码/登记注册号码
        /// </summary>
        [Display(Name = "证件号码/登记注册号码"), StringLength(20)]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), MinLength(10)]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), MinLength(10)]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 持股比例
        /// </summary>
        [Display(Name = "持股比例"), DataType(DataType.Currency)]
        public decimal? SharesProportion { get; set; }

        public string 信息更新日期 { get; set; }

        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
