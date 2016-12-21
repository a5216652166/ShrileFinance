namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;

    public class OrganizationStateSegment : AbsSegment
    {

        public OrganizationStateSegment()
        {
            信息更新日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "D"; }
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(2, false)]
        public string 基本户状态
        {
            get { return " "; }
        }

        /// <summary>
        /// 企业规模
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(3, false)]
        public string EnterpriseScale { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(4, false)]
        public string InstitutionsState { get; set; }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(5, false)]
        public string 信息更新日期 { get; set; }

        [MetaCode(40, MetaCodeTypeEnum.ANC), SegmentRule(13, true)]
        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
