namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;

    public class ParentSegment : AbsSegment
    {
        public ParentSegment()
        {
            信息更新日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "I"; }
        }

        /// <summary>
        /// 上级机构名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(2, true)]
        public string SuperInstitutionsName { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(84, false)]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [MetaCode(10, MetaCodeTypeEnum.AN), SegmentRule(104, false)]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [MetaCode(18, MetaCodeTypeEnum.AN), SegmentRule(114, false)]
        public string InstitutionCreditCode { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(132, true)]
        public string 信息更新日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(140, true)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
