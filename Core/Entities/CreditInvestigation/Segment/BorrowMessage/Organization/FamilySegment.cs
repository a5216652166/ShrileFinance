namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;

    public class FamilySegment : AbsSegment
    {
        public FamilySegment()
        {
            信息更新日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "B"; }
        }

        /// <summary>
        /// 主要关系人姓名
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(2, true)]
        public string MianName { get; set; }

        /// <summary>
        /// 主要关系人证件类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(82, true)]
        public string MainType { get; set; }

        /// <summary>
        /// 主要关系人证件号码
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(84, true)]
        public string MainCode { get; set; }

        /// <summary>
        /// 家族成员关系
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(104, true)]
        public string Relationship { get; set; }

        /// <summary>
        /// 家族成员姓名
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(105, true)]
        public string Name { get; set; }

        /// <summary>
        /// 家族成员证件类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(185, true)]
        public string CertificateType { get; set; }

        /// <summary>
        /// 家族成员证件号码
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.ANC), SegmentRule(185, true)]
        public string CertificateCode { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(207, true)]
        public string 信息更新日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(215, false)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
