namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 2007版现金流量表信息记录
    /// </summary>
    public class CashFlowParagraph
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string Type
        {
            get { return "I"; }
        }

        /// <summary>
        /// 销售商品和提供劳务收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(2, false)]
        public decimal? SaleGoodsCash { get; set; }

        /// <summary>
        /// 收到的税费返还
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(22, false)]
        public decimal? TaxesRefunds { get; set; }

        /// <summary>
        /// 收到其他与经营活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(42, false)]
        public decimal? ReceiveOperatingActivitiesCash { get; set; }

        /// <summary>
        /// 经营活动现金流入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(62, false)]
        public decimal? OperatingActivitiesCashInflows { get; set; }

        /// <summary>
        /// 购买商品、接受劳务支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public decimal? BuyGoodsCash { get; set; }

        /// <summary>
        /// 支付给职工以及为职工支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(102, false)]
        public decimal? PayEmployeeCash { get; set; }

        /// <summary>
        /// 支付的各项税费
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(122, false)]
        public decimal? PayAllTaxes { get; set; }

        /// <summary>
        /// 支付其他与经营活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(142, false)]
        public decimal? PayOperatingActivitiesCash { get; set; }

        /// <summary>
        /// 经营活动现金流出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(162, false)]
        public decimal? OperatingActivitiesCashOutflows { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(182, true)]
        public decimal OperatingActivitieCashNet { get; set; }

        /// <summary>
        /// 收回投资所收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(202, false)]
        public decimal? RecoveryInvestmentCash { get; set; }

        /// <summary>
        /// 取得投资收益所收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(222, false)]
        public decimal? InvestmentIncomeCash { get; set; }

        /// <summary>
        /// 处置固定资产无形资产和其他长期资产所收回的现金净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(242, false)]
        public decimal? RecoveryAssetsCash { get; set; }

        /// <summary>
        /// 处置子公司及其他营业单位收到的现金净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(262, false)]
        public decimal? RecoveryChildrenCompanyCash { get; set; }

        /// <summary>
        /// 收到其他与投资活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(282, false)]
        public decimal? OtherInvestmentCash { get; set; }

        /// <summary>
        /// 投资活动现金流入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(302, false)]
        public decimal? CashInInvestmentActivities { get; set; }

        /// <summary>
        /// 购建固定资产无形资产和其他长期资产所支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(322, false)]
        public decimal? BuyAssetsCash { get; set; }

        /// <summary>
        /// 投资所支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(342, false)]
        public decimal? InvestmentPaidCash { get; set; }

        /// <summary>
        /// 取得子公司及其他营业单位支付的现金净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(362, false)]
        public decimal? GetChildrenComponyCash { get; set; }

        /// <summary>
        /// 支付其他与投资活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(382, false)]
        public decimal? PayOtherInvestmentCash { get; set; }

        /// <summary>
        /// 投资活动现金流出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(402, false)]
        public decimal? InvestmentCashOutflow { get; set; }

        /// <summary>
        /// 投资活动产生的现金流量净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(422, true)]
        public decimal InvestmentCashInflow { get; set; }

        /// <summary>
        /// 吸收投资收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(442, false)]
        public decimal? AbsorbInvestmentCash { get; set; }

        /// <summary>
        /// 取得借款收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(462, false)]
        public decimal? GetLoanCash { get; set; }

        /// <summary>
        /// 收到其他与筹资活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(482, false)]
        public decimal? GetFinancingCash { get; set; }

        /// <summary>
        /// 筹资活动现金流入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(502, false)]
        public decimal? FinancingCashInflow { get; set; }

        /// <summary>
        /// 偿还债务所支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(522, false)]
        public decimal? DebtRedemption { get; set; }

        /// <summary>
        /// 分配股利、利润或偿付利息所支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(542, false)]
        public decimal? PayCashForDividend { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(562, false)]
        public decimal? PayFinancingCash { get; set; }

        /// <summary>
        /// 支付其他与筹资活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(582, false)]
        public decimal? PayOtherFinancingCash { get; set; }

        /// <summary>
        /// 筹资活动现金流出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(602, true)]
        public decimal? FinancingCashOutflow { get; set; }

        /// <summary>
        /// 筹集活动产生的现金流量净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(622, false)]
        public decimal FinancingNetCash { get; set; }

        /// <summary>
        /// 汇率变动对现金及现金等价物的影响
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(642, true)]
        public decimal? ExchangeRateChangeCash { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额(五)
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(662, false)]
        public decimal CashIncrease5 { get; set; }

        /// <summary>
        /// 期初现金及现金等价物余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(682, true)]
        public decimal? BeginCashBalance { get; set; }

        /// <summary>
        /// 期末现金及现金等价物余额(六)
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(702, false)]
        public decimal FinalCashBalance6 { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(722, false)]
        public decimal? NetProfit { get; set; }

        /// <summary>
        /// 资产减值准备
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(742, false)]
        public decimal? AssetImpairment { get; set; }

        /// <summary>
        /// 固定资产折旧、油气资 产折耗、生产性生物资产折旧
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(762, false)]
        public decimal? AssetsDepreciation { get; set; }

        /// <summary>
        /// 无形资产摊销
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(782, false)]
        public decimal? IntangibleAssetsAmortization { get; set; }

        /// <summary>
        /// 长期待摊费用摊销
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(802, false)]
        public decimal? LongPrepaidExpenses { get; set; }

        /// <summary>
        /// 待摊费用减少
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(822, false)]
        public decimal? PrepaidExpensesLessen { get; set; }

        /// <summary>
        /// 预提费用增
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(842, false)]
        public decimal? AccruedExpenses { get; set; }

        /// <summary>
        /// 处置固定资产无形资产和其他长期资产的损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(862, false)]
        public decimal? Assetloss { get; set; }

        /// <summary>
        /// 固定资产报废损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(882, false)]
        public decimal? FixedAssetsScrap { get; set; }

        /// <summary>
        /// 公允价值变动损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(902, false)]
        public decimal? FairChanges { get; set; }

        /// <summary>
        /// 财务费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(922, false)]
        public decimal? FinancialExpenses { get; set; }

        /// <summary>
        /// 投资损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(942, false)]
        public decimal? InvestmentLosses { get; set; }

        /// <summary>
        /// 递延所得税资产减少
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(962, false)]
        public decimal? DeferredIncomeTaxLessen { get; set; }

        /// <summary>
        /// 递延所得税资产增加
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(982, false)]
        public decimal? DeferredIncomeTaAdd { get; set; }

        /// <summary>
        /// 存货的减少
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1002, false)]
        public decimal? Inventoryreduction { get; set; }

        /// <summary>
        /// 经营性应收项目的减少
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1022, false)]
        public decimal? ReceivableItemLosses { get; set; }

        /// <summary>
        /// 经营性应付项目的增加
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1042, false)]
        public decimal? PayablesAdd { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1062, false)]
        public decimal? Other { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1082, false)]
        public decimal? OperatingCashFlowsNet { get; set; }

        /// <summary>
        /// 债务转为资本
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1102, false)]
        public decimal? CapitalDebt { get; set; }

        /// <summary>
        /// 一年内到期的可转换公司债券
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1122, false)]
        public decimal? CorporateBondInYear { get; set; }

        /// <summary>
        /// 融资租入固定资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1142, false)]
        public decimal? FinancingFixedAssets { get; set; }

        /// <summary>
        /// 现金的期末余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1162, false)]
        public decimal? EndingBalance { get; set; }

        /// <summary>
        /// 现金的期初余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1182, false)]
        public decimal? BeginBalance { get; set; }

        /// <summary>
        /// 现金等价物的期末余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1202, false)]
        public decimal? CashEquivalentsEndingBalance { get; set; }

        /// <summary>
        /// 现金等价物的期初余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1222, false)]
        public decimal? CashEquivalentsBeginBalance { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(1242, false)]
        public decimal? CashEquivalentsNetIncrease { get; set; }
    }
}
