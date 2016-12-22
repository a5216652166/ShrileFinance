using Core.Entities.Customers.Enterprise;

namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 2007版资产负债表信息记录
    /// </summary>
    public class LiabilitiesParagraph : AbsSegment
    {
        public LiabilitiesParagraph() { }

        public LiabilitiesParagraph(Liabilities liabilities)
        {
            AutoMapper.Mapper.Map(liabilities, this);
        }
        
        /// <summary>
        /// 信息类别
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "G"; }
        }

        /// <summary>
        /// 货币资金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(2, false)]
        public string MonetaryFund { get; set; }

        /// <summary>
        /// 交易性金融资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(22, false)]
        public string TransactionAssets { get; set; }

        /// <summary>
        /// 应收票据
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(42, false)]
        public string NoteReceivable { get; set; }

        /// <summary>
        /// 应收账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(62, false)]
        public string AccountsReceivable { get; set; }

        /// <summary>
        /// 预付账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public string AdvancePayment { get; set; }

        /// <summary>
        /// 应收利息
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(102, false)]
        public string InterestReceivable { get; set; }

        /// <summary>
        /// 应收股利
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(122, false)]
        public string DividendsReceivable { get; set; }

        /// <summary>
        /// 其他应收款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(142, false)]
        public string OtherReceivables { get; set; }

        /// <summary>
        /// 存货
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(162, false)]
        public string Inventory { get; set; }

        /// <summary>
        /// 一年内到期的非流动资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(182, false)]
        public string NonCurrentAssetsInYear { get; set; }

        /// <summary>
        /// 其他流动资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(202, false)]
        public string OtherCurrentAssets { get; set; }

        /// <summary>
        /// 流动资产合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(222, true)]
        public string TotalCurrentAssets { get; set; }

        /// <summary>
        /// 可供出售的金融资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(242, false)]
        public string CanSaleAsset { get; set; }

        /// <summary>
        /// 持有至到期的投资
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(262, false)]
        public string MaturityInvestment { get; set; }

        /// <summary>
        /// 长期股权投资
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(282, false)]
        public string LongEquity { get; set; }

        /// <summary>
        /// 长期应收款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(302, false)]
        public string LongReceivables { get; set; }

        /// <summary>
        /// 投资性房地产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(322, false)]
        public string InvestmentRealEstate { get; set; }

        /// <summary>
        /// 固定资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(342, false)]
        public string FixedAssets { get; set; }

        /// <summary>
        /// 在建工程
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(362, false)]
        public string ConstructionProject { get; set; }

        /// <summary>
        /// 工程物资
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(382, false)]
        public string EngineeringMaterials { get; set; }

        /// <summary>
        /// 固定资产清理
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(402, false)]
        public string FixedAssetsLiquidation { get; set; }

        /// <summary>
        /// 生产性生物资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(422, false)]
        public string ProductiveBiologicalAssets { get; set; }

        /// <summary>
        /// 油气资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(442, false)]
        public string OilGasAssets { get; set; }

        /// <summary>
        /// 无形资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(462, false)]
        public string IntangibleAssets { get; set; }

        /// <summary>
        /// 开发支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(482, false)]
        public string DevelopmentExpenditure { get; set; }

        /// <summary>
        /// 商誉
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(502, false)]
        public string Goodwill { get; set; }

        /// <summary>
        /// 长期待摊费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(522, false)]
        public string LongArepaidExpenses { get; set; }

        /// <summary>
        /// 递延所得税资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(542, false)]
        public string DeferredTaxAssets { get; set; }

        /// <summary>
        /// 其他非流动资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(562, false)]
        public string OtherNonCurrentAssets { get; set; }

        /// <summary>
        /// 非流动资产合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(582, true)]
        public string TotalNonCurrentAssets { get; set; }

        /// <summary>
        /// 资产总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(602, true)]
        public string TotalAssets { get; set; }

        /// <summary>
        /// 短期借款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(622, false)]
        public string ShortLoan { get; set; }

        /// <summary>
        /// 交易性金融负债
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(642, false)]
        public string TransactionalFinancialLiabilities { get; set; }

        /// <summary>
        /// 应付票据
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(662, false)]
        public string NotesPayable { get; set; }

        /// <summary>
        /// 应付账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(682, false)]
        public string AccountsPayable { get; set; }

        /// <summary>
        /// 预收账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(702, false)]
        public string AccountsAdvance { get; set; }

        /// <summary>
        /// 应付利息
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(722, false)]
        public string InterestPayable { get; set; }

        /// <summary>
        /// 应付职工薪酬
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(742, false)]
        public string EmployeesSalary { get; set; }

        /// <summary>
        /// 应交税费
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(762, false)]
        public string PayTax { get; set; }

        /// <summary>
        /// 应付股利
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(782, false)]
        public string PayDividend { get; set; }

        /// <summary>
        /// 其他应付款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(802, false)]
        public string OtherPayable { get; set; }

        /// <summary>
        /// 一年内到期的非流动负债
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(822, false)]
        public string NonCurrentLiabilitiesInYear { get; set; }

        /// <summary>
        /// 其他流动负债
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(842, false)]
        public string OtherCurrentLiabilities { get; set; }

        /// <summary>
        /// 流动负债合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(862, true)]
        public string TotalCurrentLiabilities { get; set; }

        /// <summary>
        /// 长期借款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(882, false)]
        public string LongLoan { get; set; }

        /// <summary>
        /// 应付债券
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(902, false)]
        public string BondPayable { get; set; }

        /// <summary>
        /// 长期应付款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(922, false)]
        public string LongAcountsPayable { get; set; }

        /// <summary>
        /// 专项应付款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(942, false)]
        public string SpecialPayment { get; set; }

        /// <summary>
        /// 预计负债
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(962, false)]
        public string EstimatedLiabilities { get; set; }

        /// <summary>
        /// 递延所得税负债
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(982, false)]
        public string DeferredTaxLiability { get; set; }

        /// <summary>
        /// 其他非流动负债
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1002, false)]
        public string OtherNonCurrentLiabilities { get; set; }

        /// <summary>
        /// 非流动负债合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1022, true)]
        public string TotalNonNurrentLiabilities { get; set; }

        /// <summary>
        /// 负债合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1042, true)]
        public string TotalLiabilities { get; set; }

        /// <summary>
        /// 实收资本(或股本)
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1062, false)]
        public string PaidCapital { get; set; }

        /// <summary>
        /// 资本公积
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1082, false)]
        public string CapitalReserve { get; set; }

        /// <summary>
        /// 减:库存股
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1102, false)]
        public string Stock { get; set; }

        /// <summary>
        /// 盈余公积
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1122, false)]
        public string SurplusReserve { get; set; }

        /// <summary>
        /// 未分配利润
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1142, false)]
        public string NoProfit { get; set; }

        /// <summary>
        /// 所有者权益合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1162, true)]
        public string TotalOwnersEquity { get; set; }

        /// <summary>
        /// 负债和所有者权益合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1182, true)]
        public string TotalLiabilitiesCapital { get; set; }
    }
}
