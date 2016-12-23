namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;
    using DatagramFile;

    /// <summary>
    /// 欠息基础段
    /// </summary>
    public class DebitInterestBaseSegment : AbsSegment
    {
        public DebitInterestBaseSegment(string loanCardCode)
        {
            LoanCardCode = loanCardCode;
            业务发生日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        protected DebitInterestBaseSegment() : base()
        {
        }

        [MetaCode(4, MetaCodeTypeEnum.N), SegmentRule(1, true, Describe = "本信息记录的长度")]
        public string 信息记录长度 { get; set; }

        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(5, true, Describe = "本信息记录的类型")]
        public string 信息记录类型
        {
            get { return "26"; }
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(7, true, Describe = "本信息记录的类别")]
        public string 信息类别
        {
            get { return "B"; }
        }

        [MetaCode(11, MetaCodeTypeEnum.AN), SegmentRule(8, true, Describe = "填写数据发生机构的代码，细化到县（区）级机构")]
        public string 金融机构代码
        {
            get { return AbsDatagramFile.FinancialOrganizationCode; }
        }

        /// <summary>
        /// 中征码/贷款卡编码
        /// </summary>
        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(19, true, Describe = "主业务借款人的贷款卡编码，借款人在企业征信系统的唯一标识")]
        public string LoanCardCode { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(35, true)]
        public string 信息记录操作类型
        {
            get { return "1"; }
        }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(36, true)]
        public string 业务发生日期 { get; set; }

        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(44, true)]
        public string 信息记录跟踪编号
        {
            get
            {
                return string.Empty.PadLeft(20, '0');
            }
        }
    }
}
