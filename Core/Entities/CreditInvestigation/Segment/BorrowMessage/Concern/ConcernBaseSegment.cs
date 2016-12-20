namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern
{
    using System.ComponentModel.DataAnnotations;
    using DatagramFile;

    public class ConcernBaseSegment : AbsSegment
    {
        [MetaCode(4, MetaCodeTypeEnum.N), SegmentRule(1, true)]
        public string 信息记录长度 { get; set; }

        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(5, true)]
        public string 信息记录类型 { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(7, true)]
        public string 信息类别
        {
            get { return "B"; }
        }

        [MetaCode(11, MetaCodeTypeEnum.AN), SegmentRule(8, true)]
        public string 金融机构代码
        {
            get { return AbsDatagramFile.FinancialOrganizationCode; }
        }

        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(19, true)]
        public string 借款人名称 { get; set; }

        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(99, true)]
        public string 贷款卡编码 { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(115, true)]
        public string 信息记录操作类型
        {
            get { return "1"; }
        }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(116, true)]
        public string 业务发生日期 { get; set; }

        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(124, true)]
        public string 信息记录跟踪编号
        {
            get { return string.Empty.PadLeft(20, '0'); }
        }
    }
}
