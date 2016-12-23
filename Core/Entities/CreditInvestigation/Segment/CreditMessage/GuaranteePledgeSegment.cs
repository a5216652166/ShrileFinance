namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using AutoMapper;
    using Core.Entities.Loan;

    /// <summary>
    /// 质押
    /// </summary>
    public class GuaranteePledgeSegment : AbsSegment
    {
        public GuaranteePledgeSegment(GuarantyContractPledge mortgage, CreditContract credit)
        {
            Mapper.Map(mortgage, this);
            质押合同编号 = mortgage.Id.ToString();
            CreditcardCode = credit.Organization.LoanCardCode;
            SigningDate = mortgage.SigningDate == null ? "" : mortgage.SigningDate.Value.ToString("yyyyMMdd");
        }

        protected GuaranteePledgeSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "F"; }
        }

        /// <summary>
        /// 质押合同编号
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "金融机构标识一笔质押合同的唯一编号")]
        public string 质押合同编号 { get; set; }

        /// <summary>
        /// 质押序号
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(62, true, Describe = "区别多个质押的序列号")]
        public string PledgeNumber { get; set; }

        /// <summary>
        /// 出质人名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(64, true)]
        public string Name { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(144, true)]
        public string CreditcardCode { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(160, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 质押物价值
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(163, true)]
        public string CollateralValue { get; set; }

        /// <summary>
        /// 合同签订日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(183, true)]
        public string SigningDate { get; set; }

        /// <summary>
        /// 质押物种类
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(191, true)]
        public string PledgeType { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(192, true)]
        public string 质押币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 质押物金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(195, true)]
        public string Margin { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(215, true)]
        public string EffectiveState { get; set; }
    }
}
