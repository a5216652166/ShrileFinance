namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 2007版现金流量表信息记录
    /// </summary>
    public class CashFlowParagraph : AbsSegment
    {
        public CashFlowParagraph()
        {
        }

        public CashFlowParagraph(CashFlow cashFlow)
        {
            AutoMapper.Mapper.Map(cashFlow, this);
        }

        /// <summary>
        /// 信息类别
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.ANC), SegmentRule(1, true)]
        public string 信息类别
        {
            get { return "I"; }
        }

        /// <summary>
        /// 销售商品和提供劳务收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(2, false)]
        public string SaleGoodsCash { get; set; }

        /// <summary>
        /// 收到的税费返还
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(22, false)]
        public string TaxesRefunds { get; set; }

        /// <summary>
        /// 收到其他与经营活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(42, false)]
        public string ReceiveOperatingActivitiesCash { get; set; }

        /// <summary>
        /// 经营活动现金流入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(62, false)]
        public string OperatingActivitiesCashInflows { get; set; }

        /// <summary>
        /// 购买商品、接受劳务支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(82, false)]
        public string BuyGoodsCash { get; set; }

        /// <summary>
        /// 支付给职工以及为职工支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(102, false)]
        public string PayEmployeeCash { get; set; }

        /// <summary>
        /// 支付的各项税费
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(122, false)]
        public string PayAllTaxes { get; set; }

        /// <summary>
        /// 支付其他与经营活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(142, false)]
        public string PayOperatingActivitiesCash { get; set; }

        /// <summary>
        /// 经营活动现金流出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(162, false)]
        public string OperatingActivitiesCashOutflows { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(182, true)]
        public string OperatingActivitieCashNet { get; set; }

        /// <summary>
        /// 收回投资所收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(202, false)]
        public string RecoveryInvestmentCash { get; set; }

        /// <summary>
        /// 取得投资收益所收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(222, false)]
        public string InvestmentIncomeCash { get; set; }

        /// <summary>
        /// 处置固定资产无形资产和其他长期资产所收回的现金净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(242, false)]
        public string RecoveryAssetsCash { get; set; }

        /// <summary>
        /// 处置子公司及其他营业单位收到的现金净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(262, false)]
        public string RecoveryChildrenCompanyCash { get; set; }

        /// <summary>
        /// 收到其他与投资活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(282, false)]
        public string OtherInvestmentCash { get; set; }

        /// <summary>
        /// 投资活动现金流入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(302, false)]
        public string CashInInvestmentActivities { get; set; }

        /// <summary>
        /// 购建固定资产无形资产和其他长期资产所支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(322, false)]
        public string BuyAssetsCash { get; set; }

        /// <summary>
        /// 投资所支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(342, false)]
        public string InvestmentPaidCash { get; set; }

        /// <summary>
        /// 取得子公司及其他营业单位支付的现金净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(362, false)]
        public string GetChildrenComponyCash { get; set; }

        /// <summary>
        /// 支付其他与投资活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(382, false)]
        public string PayOtherInvestmentCash { get; set; }

        /// <summary>
        /// 投资活动现金流出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(402, false)]
        public string InvestmentCashOutflow { get; set; }

        /// <summary>
        /// 投资活动产生的现金流量净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(422, true)]
        public string InvestmentCashInflow { get; set; }

        /// <summary>
        /// 吸收投资收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(442, false)]
        public string AbsorbInvestmentCash { get; set; }

        /// <summary>
        /// 取得借款收到的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(462, false)]
        public string GetLoanCash { get; set; }

        /// <summary>
        /// 收到其他与筹资活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(482, false)]
        public string GetFinancingCash { get; set; }

        /// <summary>
        /// 筹资活动现金流入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(502, false)]
        public string FinancingCashInflow { get; set; }

        /// <summary>
        /// 偿还债务所支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(522, false)]
        public string DebtRedemption { get; set; }

        /// <summary>
        /// 分配股利、利润或偿付利息所支付的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(542, false)]
        public string PayCashForDividend { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(562, false)]
        public string PayFinancingCash { get; set; }

        /// <summary>
        /// 支付其他与筹资活动有关的现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(582, false)]
        public string PayOtherFinancingCash { get; set; }

        /// <summary>
        /// 筹资活动现金流出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(602, true)]
        public string FinancingCashOutflow { get; set; }

        /// <summary>
        /// 筹集活动产生的现金流量净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(622, false)]
        public string FinancingNetCash { get; set; }

        /// <summary>
        /// 汇率变动对现金及现金等价物的影响
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(642, true)]
        public string ExchangeRateChangeCash { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额(五)
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(662, false)]
        public string CashIncrease5 { get; set; }

        /// <summary>
        /// 期初现金及现金等价物余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(682, true)]
        public string BeginCashBalance { get; set; }

        /// <summary>
        /// 期末现金及现金等价物余额(六)
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(702, false)]
        public string FinalCashBalance6 { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(722, false)]
        public string NetProfit { get; set; }

        /// <summary>
        /// 资产减值准备
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(742, false)]
        public string AssetImpairment { get; set; }

        /// <summary>
        /// 固定资产折旧、油气资 产折耗、生产性生物资产折旧
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(762, false)]
        public string AssetsDepreciation { get; set; }

        /// <summary>
        /// 无形资产摊销
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(782, false)]
        public string IntangibleAssetsAmortization { get; set; }

        /// <summary>
        /// 长期待摊费用摊销
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(802, false)]
        public string LongPrepaidExpenses { get; set; }

        /// <summary>
        /// 待摊费用减少
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(822, false)]
        public string PrepaidExpensesLessen { get; set; }

        /// <summary>
        /// 预提费用增
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(842, false)]
        public string AccruedExpenses { get; set; }

        /// <summary>
        /// 处置固定资产无形资产和其他长期资产的损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(862, false)]
        public string Assetloss { get; set; }

        /// <summary>
        /// 固定资产报废损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(882, false)]
        public string FixedAssetsScrap { get; set; }

        /// <summary>
        /// 公允价值变动损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(902, false)]
        public string FairChanges { get; set; }

        /// <summary>
        /// 财务费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(922, false)]
        public string FinancialExpenses { get; set; }

        /// <summary>
        /// 投资损失
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(942, false)]
        public string InvestmentLosses { get; set; }

        /// <summary>
        /// 递延所得税资产减少
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(962, false)]
        public string DeferredIncomeTaxLessen { get; set; }

        /// <summary>
        /// 递延所得税资产增加
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(982, false)]
        public string DeferredIncomeTaAdd { get; set; }

        /// <summary>
        /// 存货的减少
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1002, false)]
        public string Inventoryreduction { get; set; }

        /// <summary>
        /// 经营性应收项目的减少
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1022, false)]
        public string ReceivableItemLosses { get; set; }

        /// <summary>
        /// 经营性应付项目的增加
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1042, false)]
        public string PayablesAdd { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1062, false)]
        public string Other { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1082, false)]
        public string OperatingCashFlowsNet { get; set; }

        /// <summary>
        /// 债务转为资本
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1102, false)]
        public string CapitalDebt { get; set; }

        /// <summary>
        /// 一年内到期的可转换公司债券
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1122, false)]
        public string CorporateBondInYear { get; set; }

        /// <summary>
        /// 融资租入固定资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1142, false)]
        public string FinancingFixedAssets { get; set; }

        /// <summary>
        /// 现金的期末余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1162, false)]
        public string EndingBalance { get; set; }

        /// <summary>
        /// 现金的期初余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1182, false)]
        public string BeginBalance { get; set; }

        /// <summary>
        /// 现金等价物的期末余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1202, false)]
        public string CashEquivalentsEndingBalance { get; set; }

        /// <summary>
        /// 现金等价物的期初余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1222, false)]
        public string CashEquivalentsBeginBalance { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(1242, false)]
        public string CashEquivalentsNetIncrease { get; set; }
    }
}
