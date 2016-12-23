namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using AutoMapper;
    using Core.Entities.Loan;

    /// <summary>
    /// 担保
    /// </summary>
    public class GuaranteeSegment : AbsSegment
    {
        public GuaranteeSegment(CreditContract credit, GuarantyContract guaranty)
        {
            Mapper.Map(guaranty, this);
            保证合同编号 = guaranty.Id.ToString();
            CreditcardCode = credit.Organization.LoanCardCode;
            SigningDate = guaranty.SigningDate == null ? "" : guaranty.SigningDate.Value.ToString("yyyyMMdd");
        }

        protected GuaranteeSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "D"; }
        }

        /// <summary>
        /// 保证合同编号
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "金融机构标识一笔保证合同的唯一编号")]
        public string 保证合同编号 { get; set; }

        /// <summary>
        /// 保证人姓名
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(62, true)]
        public string Name { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(142, true)]
        public string CreditcardCode { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(158, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 保证金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(161, true)]
        public string Margin { get; set; }

        /// <summary>
        /// 合同签订日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(181, true)]
        public string SigningDate { get; set; }

        /// <summary>
        /// 担保形式
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(189, true)]
        public string GuaranteeForm { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(190, true)]
        public string EffectiveState { get; set; }
    }
}
