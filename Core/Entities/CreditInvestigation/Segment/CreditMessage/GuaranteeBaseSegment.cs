namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;
    using DatagramFile;
    using Loan;

    /// <summary>
    /// 保证合同基础段
    /// </summary>
    public class GuaranteeBaseSegment : AbsSegment
    {
        public GuaranteeBaseSegment(Record.RecordTypeEnum type, CreditContract creditContract)
        {
            信息记录类型 = type.ToString("D");
            LoanCardCode = creditContract.Organization.LoanCardCode;
            CreditId = creditContract.Id.ToString();
            业务发生日期 = creditContract.EffectiveDate.ToString("yyyyMMdd");
        }

        protected GuaranteeBaseSegment() : base()
        {
        }

        [MetaCode(4, MetaCodeTypeEnum.N), SegmentRule(1, true, Describe = "本信息记录的长度")]
        public string 信息记录长度 { get; set; }

        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(5, true, Describe = "本信息记录的类型")]
        public string 信息记录类型 { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(7, true, Describe = "本信息记录的类别")]
        public override char SegmentType
        {
            get { return 'B'; }
        }

        [MetaCode(11, MetaCodeTypeEnum.AN), SegmentRule(8, true, Describe = "填写数据发生机构的代码，细化到县（区）级机构")]
        public string 金融机构代码
        {
            get { return AbsDatagramFile.FINANCIAL_ORGANIZATION_CODE; }
        }

        /// <summary>
        /// 中征码/贷款卡编码(根据贷款合同中机构ID获取中征码手动映射)
        /// </summary>
        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(19, true, Describe = "主业务借款人的贷款卡编码，借款人在企业征信系统的唯一标识")]
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 主合同编码(贷款合同ID手动映射)
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(35, true, Describe = "金融机构自己定义和使用的，标识一笔信贷业务的唯一号码")]
        public string CreditId { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(95, true, Describe = "该担保信息记录对应的业务种类")]
        public string 信贷业务种类
        {
            get { return "1"; }
        }

        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(96, true)]
        public string 信息记录操作类型
        {
            get { return "1"; }
        }

        [MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(97, true)]
        public string 业务发生日期 { get; set; }

        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(105, true)]
        public string 信息记录跟踪编号
        {
            get
            {
                return string.Empty.PadLeft(20, '0');
            }
        }
    }
}
