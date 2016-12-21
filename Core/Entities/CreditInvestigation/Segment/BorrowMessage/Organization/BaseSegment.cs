namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseSegment : AbsSegment
    {
        public BaseSegment()
        {
            数据提取日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 类别
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get
            {
                return "B";
            }
        }

        /// <summary>
        /// 客户号
        /// </summary>
        [MetaCode(40, MetaCodeTypeEnum.AN), SegmentRule(2, true, Describe = "金融机构系统内部对该客户的编号")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 管理行代码
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(42, true, Describe = "对于基本户，填写开户行；对于信贷户，填写管护行")]
        public string ManagementerCode { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        [Display(Name = "客户类型"), StringLength(1), Required]
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(62, true)]
        public string CustomerType { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [MetaCode(18, MetaCodeTypeEnum.AN), SegmentRule(63, false, Describe = "征信中心赋予该客户的18位机构信用代码")]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [MetaCode(10, MetaCodeTypeEnum.AN), SegmentRule(81, false, Describe = "质检部门颁发的组织机构代码，填写格式为xxxxxxxx-x。")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(91, false)]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(93, false)]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 纳税人识别号（国税）
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(113, false)]
        public string TaxpayerIdentifyIrsNumber { get; set; }

        /// <summary>
        /// 纳税人识别号（地税）
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(133, false)]
        public string TaxpayerIdentifyLandNumber { get; set; }

        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(153, false)]
        public string 开户许可证核准号
        {
            get { return string.Empty.PadLeft(30, ' '); }
        }

        /// <summary>
        /// 中征码
        /// </summary>
        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(173, false)]
        public string LoanCardCode { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(189, true)]
        public string 数据提取日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(197, false)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
