namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 2007版利润及利润分配表信息记录
    /// </summary>
    public class ProfitsParagraph : AbsSegment
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string Type
        {
            get { return "H"; }
        }

        /// <summary>
        /// 营业收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(2, true)]
        public decimal BusinessIncome { get; set; }

        /// <summary>
        /// 营业成本
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(22, false)]
        public decimal? OperatingCost { get; set; }

        /// <summary>
        /// 营业税金及附加
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(42, false)]
        public decimal? SalesTax { get; set; }

        /// <summary>
        /// 销售费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(62, false)]
        public decimal? SellingExpenses { get; set; }

        /// <summary>
        /// 管理费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public decimal? ManagementExpenses { get; set; }

        /// <summary>
        /// 财务费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(102, false)]
        public decimal FinancialExpenses { get; set; }

        /// <summary>
        /// 资产减值损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(122, false)]
        public decimal? AssetsimpairmentLoss { get; set; }

        /// <summary>
        /// 公允价值变动净收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(142, false)]
        public decimal? FairIncome { get; set; }

        /// <summary>
        /// 投资净收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(162, false)]
        public decimal? NetInvestmentIncome { get; set; }

        /// <summary>
        /// 对联营企业和合营企业的投资收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(182, false)]
        public decimal? EnterpriseInvestmentIncome { get; set; }

        /// <summary>
        /// 营业利润
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(202, true)]
        public decimal OperatingProfit { get; set; }

        /// <summary>
        /// 营业外收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(222, false)]
        public decimal? OperatingIncome { get; set; }

        /// <summary>
        /// 营业外支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(242, false)]
        public decimal? OperatingExpenditure { get; set; }

        /// <summary>
        /// 非流动资产损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(262, false)]
        public decimal? NonCurrentAssetsLoss { get; set; }

        /// <summary>
        /// 利润总额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(282, true)]
        public decimal GrossProfit { get; set; }

        /// <summary>
        /// 所得税费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(302, false)]
        public decimal? IncomeTaxExpense { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(322, true)]
        public decimal NetProfit { get; set; }

        /// <summary>
        /// 基本每股收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(342, false)]
        public decimal? BasicEarningsShare { get; set; }

        /// <summary>
        /// 稀释每股收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(362, false)]
        public decimal? DilutedEarningsShare { get; set; }
    }
}
