namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    /// <summary>
    /// 抵押
    /// </summary>
    public class GuaranteeMortgageSegment : AbsSegment
    {
        public GuaranteeMortgageSegment(string id, string name, string creditcardCode, string signingDate)
        {
            抵押合同编号 = id;
            Name = name;
            CreditcardCode = creditcardCode;
            SigningDate = signingDate;
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "E"; }
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
        /// 贷款卡编码
        /// </summary>
        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(144, true)]
        public string CreditcardCode { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(160, false)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 抵押物评估价值
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(163, false)]
        public string AssessmentValue { get; set; }

        /// <summary>
        /// 评估日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(183, false)]
        public string AssessmentDate { get; set; }

        /// <summary>
        /// 评估机构名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(191, false)]
        public string AssessmentName { get; set; }

        /// <summary>
        /// 评估机构组织机构代码
        /// </summary>
        [MetaCode(10, MetaCodeTypeEnum.AN), SegmentRule(271, false, Describe = "技监局颁发的组织机构代码")]
        public string AssessmentOrganizationCode { get; set; }

        /// <summary>
        /// 合同签订日期（授信合同中的日期）
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(281, true)]
        public string SigningDate { get; set; }

        /// <summary>
        /// 抵押物种类
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(289, true)]
        public string CollateralType { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(290, true)]
        public string 抵押物币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 抵押物金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(293, true, Describe = "金融机构认可的抵押物评估价值折算后能承受的风险金额")]
        public string Margin { get; set; }

        /// <summary>
        /// 登记机关
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(313, true, Describe = "该处填写抵押物登记机构名称，若无明确的登记机关，填写“本机构”")]
        public string RegistrateAuthorit { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(393, false)]
        public string RegistrateDate { get; set; }

        /// <summary>
        /// 抵押物说明
        /// </summary>
        [MetaCode(400, MetaCodeTypeEnum.ANC), SegmentRule(401, true)]
        public string CollateralInstruction { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(801, true)]
        public string EffectiveState { get; set; }
    }
}
