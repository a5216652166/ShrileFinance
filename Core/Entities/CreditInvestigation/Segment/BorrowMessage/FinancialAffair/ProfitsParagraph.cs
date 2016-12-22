using Core.Entities.Customers.Enterprise;

namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 2007版利润及利润分配表信息记录
    /// </summary>
    public class ProfitsParagraph : AbsSegment
    {
        public ProfitsParagraph() { }

        public ProfitsParagraph(Profit profit)
        {
            AutoMapper.Mapper.Map(profit, this);
        }

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
        public string BusinessIncome { get; set; }

        /// <summary>
        /// 营业成本
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(22, false)]
        public string OperatingCost { get; set; }

        /// <summary>
        /// 营业税金及附加
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(42, false)]
        public string SalesTax { get; set; }

        /// <summary>
        /// 销售费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(62, false)]
        public string SellingExpenses { get; set; }

        /// <summary>
        /// 管理费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public string ManagementExpenses { get; set; }

        /// <summary>
        /// 财务费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(102, false)]
        public string FinancialExpenses { get; set; }

        /// <summary>
        /// 资产减值损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(122, false)]
        public string AssetsimpairmentLoss { get; set; }

        /// <summary>
        /// 公允价值变动净收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(142, false)]
        public string FairIncome { get; set; }

        /// <summary>
        /// 投资净收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(162, false)]
        public string NetInvestmentIncome { get; set; }

        /// <summary>
        /// 对联营企业和合营企业的投资收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(182, false)]
        public string EnterpriseInvestmentIncome { get; set; }

        /// <summary>
        /// 营业利润
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(202, true)]
        public string OperatingProfit { get; set; }

        /// <summary>
        /// 营业外收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(222, false)]
        public string OperatingIncome { get; set; }

        /// <summary>
        /// 营业外支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(242, false)]
        public string OperatingExpenditure { get; set; }

        /// <summary>
        /// 非流动资产损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(262, false)]
        public string NonCurrentAssetsLoss { get; set; }

        /// <summary>
        /// 利润总额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(282, true)]
        public string GrossProfit { get; set; }

        /// <summary>
        /// 所得税费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(302, false)]
        public string IncomeTaxExpense { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(322, true)]
        public string NetProfit { get; set; }

        /// <summary>
        /// 基本每股收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(342, false)]
        public string BasicEarningsShare { get; set; }

        /// <summary>
        /// 稀释每股收益
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(362, false)]
        public string DilutedEarningsShare { get; set; }
    }
}
