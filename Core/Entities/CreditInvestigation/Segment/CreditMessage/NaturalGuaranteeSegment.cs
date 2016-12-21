namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    public class NaturalGuaranteeSegment : AbsSegment
    {
        public NaturalGuaranteeSegment(string id)
        {
            保证合同编号 = id;
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "G"; }
        }

        /// <summary>
        /// 保证合同编号
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "金融机构标识一笔保证合同的唯一编号")]
        public string 保证合同编号 { get; set; }

        /// <summary>
        /// 保证人名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(62, true)]
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(142, true)]
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [MetaCode(18, MetaCodeTypeEnum.ANC), SegmentRule(143, true)]
        public string CertificateNumber { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(161, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 保证金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(164, true)]
        public string Margin { get; set; }

        /// <summary>
        /// 合同签订日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(184, true)]
        public string SigningDate { get; set; }

        /// <summary>
        /// 担保形式
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(192, true)]
        public string GuaranteeForm { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(193, true)]
        public string EffectiveState { get; set; }
    }
}
