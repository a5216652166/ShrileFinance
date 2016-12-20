using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 2007版现金流量表信息记录
    /// </summary>
    public class CashFlowParagraph : AbsSegment
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string Type
        {
            get { return "I"; }
        }

        /// <summary>
        /// 销售商品和提供劳务收到的现金
        /// </summary>
        public decimal? SaleGoodsCash { get; set; }

        /// <summary>
        /// 收到的税费返还
        /// </summary>
        public decimal? TaxesRefunds { get; set; }

        /// <summary>
        /// 收到其他与经营活动有关的现金
        /// </summary>
        public decimal? ReceiveOperatingActivitiesCash { get; set; }

        /// <summary>
        /// 经营活动现金流入小计
        /// </summary>
        public decimal? OperatingActivitiesCashInflows { get; set; }

        /// <summary>
        /// 购买商品、接受劳务支付的现金
        /// </summary>
        public decimal? BuyGoodsCash { get; set; }

        /// <summary>
        /// 支付给职工以及为职工支付的现金
        /// </summary>
        public decimal? PayEmployeeCash { get; set; }

        /// <summary>
        /// 支付的各项税费
        /// </summary>
        public decimal? PayAllTaxes { get; set; }

        /// <summary>
        /// 支付其他与经营活动有关的现金
        /// </summary>
        public decimal? PayOperatingActivitiesCash { get; set; }

        /// <summary>
        /// 经营活动现金流出小计
        /// </summary>
        public decimal? OperatingActivitiesCashOutflows { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额
        /// </summary>
        public decimal OperatingActivitieCashNet { get; set; }

        /// <summary>
        /// 收回投资所收到的现金
        /// </summary>
        public decimal? RecoveryInvestmentCash { get; set; }

        /// <summary>
        /// 取得投资收益所收到的现金
        /// </summary>
        public decimal? InvestmentIncomeCash { get; set; }

        /// <summary>
        /// 处置固定资产无形资产和其他长期资产所收回的现金净额
        /// </summary>
        public decimal? RecoveryAssetsCash { get; set; }

        /// <summary>
        /// 处置子公司及其他营业单位收到的现金净额
        /// </summary>
        public decimal? RecoveryChildrenCompanyCash { get; set; }

        /// <summary>
        /// 收到其他与投资活动有关的现金
        /// </summary>
        public decimal? OtherInvestmentCash { get; set; }

        /// <summary>
        /// 投资活动现金流入小计
        /// </summary>
        public decimal? CashInInvestmentActivities { get; set; }

        /// <summary>
        /// 购建固定资产无形资产和其他长期资产所支付的现金
        /// </summary>
        public decimal? BuyAssetsCash { get; set; }

        /// <summary>
        /// 投资所支付的现金
        /// </summary>
        public decimal? InvestmentPaidCash { get; set; }

        /// <summary>
        /// 取得子公司及其他营业单位支付的现金净额
        /// </summary>
        public decimal? GetChildrenComponyCash { get; set; }

        /// <summary>
        /// 支付其他与投资活动有关的现金
        /// </summary>
        public decimal? PayOtherInvestmentCash { get; set; }

        /// <summary>
        /// 投资活动现金流出小计
        /// </summary>
        public decimal? InvestmentCashOutflow { get; set; }

        /// <summary>
        /// 投资活动产生的现金流量净额
        /// </summary>
        public decimal InvestmentCashInflow { get; set; }

        /// <summary>
        /// 吸收投资收到的现金
        /// </summary>
        public decimal? AbsorbInvestmentCash { get; set; }

        /// <summary>
        /// 取得借款收到的现金
        /// </summary>
        public decimal? GetLoanCash { get; set; }

        /// <summary>
        /// 收到其他与筹资活动有关的现金
        /// </summary>
        public decimal? GetFinancingCash { get; set; }

        /// <summary>
        /// 筹资活动现金流入小计
        /// </summary>
        public decimal? FinancingCashInflow { get; set; }

        /// <summary>
        /// 偿还债务所支付的现金
        /// </summary>
        public decimal? DebtRedemption { get; set; }

        /// <summary>
        /// 分配股利、利润或偿付利息所支付的现金
        /// </summary>
        public decimal? PayCashForDividend { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public decimal? PayFinancingCash { get; set; }

        /// <summary>
        /// 支付其他与筹资活动有关的现金
        /// </summary>
        public decimal? PayOtherFinancingCash { get; set; }

        /// <summary>
        /// 筹资活动现金流出小计
        /// </summary>
        public decimal? FinancingCashOutflow { get; set; }

        /// <summary>
        /// 筹集活动产生的现金流量净额
        /// </summary>
        public decimal FinancingNetCash { get; set; }

        /// <summary>
        /// 汇率变动对现金及现金等价物的影响
        /// </summary>
        public decimal? ExchangeRateChangeCash { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额(五)
        /// </summary>
        public decimal CashIncrease5 { get; set; }

        /// <summary>
        /// 期初现金及现金等价物余额
        /// </summary>
        public decimal? BeginCashBalance { get; set; }

        /// <summary>
        /// 期末现金及现金等价物余额(六)
        /// </summary>
        public decimal FinalCashBalance6 { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        public decimal? NetProfit { get; set; }

        /// <summary>
        /// 资产减值准备
        /// </summary>
        public decimal? AssetImpairment { get; set; }

        /// <summary>
        /// 固定资产折旧、油气资 产折耗、生产性生物资产折旧
        /// </summary>
        public decimal? AssetsDepreciation { get; set; }

        /// <summary>
        /// 无形资产摊销
        /// </summary>
        public decimal? IntangibleAssetsAmortization { get; set; }

        /// <summary>
        /// 长期待摊费用摊销
        /// </summary>
        public decimal? LongPrepaidExpenses { get; set; }

        /// <summary>
        /// 待摊费用减少
        /// </summary>
        public decimal? PrepaidExpensesLessen { get; set; }

        /// <summary>
        /// 预提费用增
        /// </summary>
        public decimal? AccruedExpenses { get; set; }

        /// <summary>
        /// 处置固定资产无形资产和其他长期资产的损失
        /// </summary>
        public decimal? Assetloss { get; set; }

        /// <summary>
        /// 固定资产报废损失
        /// </summary>
        public decimal? FixedAssetsScrap { get; set; }

        /// <summary>
        /// 公允价值变动损失
        /// </summary>
        public decimal? FairChanges { get; set; }

        /// <summary>
        /// 财务费用
        /// </summary>
        public decimal? FinancialExpenses { get; set; }

        /// <summary>
        /// 投资损失
        /// </summary>
        public decimal? InvestmentLosses { get; set; }

        /// <summary>
        /// 递延所得税资产减少
        /// </summary>
        public decimal? DeferredIncomeTaxLessen { get; set; }

        /// <summary>
        /// 递延所得税资产增加
        /// </summary>
        public decimal? DeferredIncomeTaAdd { get; set; }

        /// <summary>
        /// 存货的减少
        /// </summary>
        public decimal? Inventoryreduction { get; set; }

        /// <summary>
        /// 经营性应收项目的减少
        /// </summary>
        public decimal? ReceivableItemLosses { get; set; }

        /// <summary>
        /// 经营性应付项目的增加
        /// </summary>
        public decimal? PayablesAdd { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public decimal? Other { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额
        /// </summary>
        public decimal? OperatingCashFlowsNet { get; set; }

        /// <summary>
        /// 债务转为资本
        /// </summary>
        public decimal? CapitalDebt { get; set; }

        /// <summary>
        /// 一年内到期的可转换公司债券
        /// </summary>
        public decimal? CorporateBondInYear { get; set; }

        /// <summary>
        /// 融资租入固定资产
        /// </summary>
        public decimal? FinancingFixedAssets { get; set; }

        /// <summary>
        /// 现金的期末余额
        /// </summary>
        public decimal? EndingBalance { get; set; }

        /// <summary>
        /// 现金的期初余额
        /// </summary>
        public decimal? BeginBalance { get; set; }

        /// <summary>
        /// 现金等价物的期末余额
        /// </summary>
        public decimal? CashEquivalentsEndingBalance { get; set; }

        /// <summary>
        /// 现金等价物的期初余额
        /// </summary>
        public decimal? CashEquivalentsBeginBalance { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额
        /// </summary>
        public decimal? CashEquivalentsNetIncrease { get; set; }
    }
}
