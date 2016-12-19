namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreditContract
    {
        public string 信息类别
        {
            get { return "D"; }
        }

        /// <summary>
        /// 借款人姓名
        /// </summary>
        [StringLength(80), Required]
        public string InstitutionChName { get; set; }

        public string 授信协议号码
        {
            get { return string.Empty.PadLeft(60, ' '); }
        }

        /// <summary>
        /// 授信合同生效日期
        /// </summary>
        [StringLength(8), MinLength(8), Required]
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// 授信合同终止日期
        /// </summary>
        [StringLength(8), MinLength(8), Required]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// 合同有效状态(需手动转换征信里面只有是/否)
        /// </summary>
        [Required, StringLength(1)]
        public string EffectiveStatus { get; set; }

        public string 银团标志
        {
            get { return "2"; }
        }

        /// <summary>
        /// 担保标志(需手动转换征信里面只有是/否)
        /// </summary>
        [StringLength(1), Required]
        public string HasGuarantee { get; set; }
    }
}
