namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    public class NaturalMortgageSegment : AbsSegment
    {
        public NaturalMortgageSegment(string id)
        {
            抵押合同编号 = id;
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "H"; }
        }

        /// <summary>
        /// 抵押合同编号
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "金融机构标识一笔抵押合同的唯一编号")]
        public string 抵押合同编号 { get; set; }

        /// <summary>
        /// 抵押序号
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.AN), SegmentRule(62, true, Describe = "区别多个抵押的序列号")]
        public string MortgageNumber { get; set; }

        /// <summary>
        /// 抵押人名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(64, true)]
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(144, true)]
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [MetaCode(18, MetaCodeTypeEnum.ANC), SegmentRule(145, true)]
        public string CertificateNumber { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(163, false)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 抵押物评估价值
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(166, false)]
        public string AssessmentValue { get; set; }

        /// <summary>
        /// 评估日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(186, false)]
        public string AssessmentDate { get; set; }

        /// <summary>
        /// 评估机构名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(194, false)]
        public string AssessmentName { get; set; }

        /// <summary>
        /// 评估机构组织机构代码
        /// </summary>
        [MetaCode(10, MetaCodeTypeEnum.AN), SegmentRule(274, false)]
        public string AssessmentOrganizationCode { get; set; }

        /// <summary>
        /// 合同签订日期（授信合同中的日期）
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(284, true)]
        public string SigningDate { get; set; }

        /// <summary>
        /// 抵押物种类
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(292, true)]
        public string CollateralType { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(293, true)]
        public string 抵押物币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 抵押物金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(296, true)]
        public string Margin { get; set; }

        /// <summary>
        /// 登记机关
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(316, true)]
        public string RegistrateAuthorit { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(396, false)]
        public string RegistrateDate { get; set; }

        /// <summary>
        /// 抵押物说明
        /// </summary>
        [MetaCode(400, MetaCodeTypeEnum.ANC), SegmentRule(404, true)]
        public string CollateralInstruction { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(804, true)]
        public string EffectiveState { get; set; }
    }
}
