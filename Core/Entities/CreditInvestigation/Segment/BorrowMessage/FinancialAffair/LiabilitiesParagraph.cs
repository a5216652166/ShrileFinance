using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 2007版资产负债表信息记录
    /// </summary>
    public class LiabilitiesParagraph
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string Type
        {
            get { return "G"; }
        }

        /// <summary>
        /// 货币资金
        /// </summary>
        public decimal? MonetaryFund { get; set; }

        /// <summary>
        /// 交易性金融资产
        /// </summary>
        public decimal? TransactionAssets { get; set; }

        /// <summary>
        /// 应收票据
        /// </summary>
        public decimal? NoteReceivable { get; set; }

        /// <summary>
        /// 应收账款
        /// </summary>
        public decimal? AccountsReceivable { get; set; }

        /// <summary>
        /// 预付账款
        /// </summary>
        public decimal? AdvancePayment { get; set; }

        /// <summary>
        /// 应收利息
        /// </summary>
        public decimal? InterestReceivable { get; set; }

        /// <summary>
        /// 应收股利
        /// </summary>
        public decimal? DividendsReceivable { get; set; }

        /// <summary>
        /// 其他应收款
        /// </summary>
        public decimal? OtherReceivables { get; set; }

        /// <summary>
        /// 存货
        /// </summary>
        public decimal? Inventory { get; set; }

        /// <summary>
        /// 一年内到期的非流动资产
        /// </summary>
        public decimal? NonCurrentAssetsInYear { get; set; }

        /// <summary>
        /// 其他流动资产
        /// </summary>
        public decimal? OtherCurrentAssets { get; set; }

        /// <summary>
        /// 流动资产合计
        /// </summary>
        public decimal TotalCurrentAssets { get; set; }

        /// <summary>
        /// 可供出售的金融资产
        /// </summary>
        public decimal? CanSaleAsset { get; set; }


        /// <summary>
        /// 持有至到期的投资
        /// </summary>
        public decimal? MaturityInvestment { get; set; }

        /// <summary>
        /// 长期股权投资
        /// </summary>
        public decimal? LongEquity { get; set; }

        /// <summary>
        /// 长期应收款
        /// </summary>
        public decimal? LongReceivables { get; set; }

        /// <summary>
        /// 投资性房地产
        /// </summary>
        public decimal? InvestmentRealEstate { get; set; }

        /// <summary>
        /// 固定资产
        /// </summary>
        public decimal? FixedAssets { get; set; }

        /// <summary>
        /// 在建工程
        /// </summary>
        public decimal? ConstructionProject { get; set; }

        /// <summary>
        /// 工程物资
        /// </summary>
        public decimal? EngineeringMaterials { get; set; }

        /// <summary>
        /// 固定资产清理
        /// </summary>
        public decimal? FixedAssetsLiquidation { get; set; }

        /// <summary>
        /// 生产性生物资产
        /// </summary>
        public decimal? ProductiveBiologicalAssets { get; set; }

        /// <summary>
        /// 油气资产
        /// </summary>
        public decimal? OilGasAssets { get; set; }

        /// <summary>
        /// 无形资产
        /// </summary>
        public decimal? IntangibleAssets { get; set; }

        /// <summary>
        /// 开发支出
        /// </summary>
        public decimal? DevelopmentExpenditure { get; set; }

        /// <summary>
        /// 商誉
        /// </summary>
        public decimal? Goodwill { get; set; }

        /// <summary>
        /// 长期待摊费用
        /// </summary>
        public decimal? LongArepaidExpenses { get; set; }

        /// <summary>
        /// 递延所得税资产
        /// </summary>
        public decimal? DeferredTaxAssets { get; set; }

        /// <summary>
        /// 其他非流动资产
        /// </summary>
        public decimal? OtherNonCurrentAssets { get; set; }

        /// <summary>
        /// 非流动资产合计
        /// </summary>
        public decimal TotalNonCurrentAssets { get; set; }

        /// <summary>
        /// 资产总计
        /// </summary>
        public decimal TotalAssets { get; set; }

        /// <summary>
        /// 短期借款
        /// </summary>
        public decimal? ShortLoan { get; set; }

        /// <summary>
        /// 交易性金融负债
        /// </summary>
        public decimal? TransactionalFinancialLiabilities { get; set; }

        /// <summary>
        /// 应付票据
        /// </summary>
        public decimal? NotesPayable { get; set; }

        /// <summary>
        /// 应付账款
        /// </summary>
        public decimal? AccountsPayable { get; set; }

        /// <summary>
        /// 预收账款
        /// </summary>
        public decimal? AccountsAdvance { get; set; }

        /// <summary>
        /// 应付利息
        /// </summary>
        public decimal? InterestPayable { get; set; }

        /// <summary>
        /// 应付职工薪酬
        /// </summary>
        public decimal? EmployeesSalary { get; set; }

        /// <summary>
        /// 应交税费
        /// </summary>
        public decimal? PayTax { get; set; }

        /// <summary>
        /// 应付股利
        /// </summary>
        public decimal? PayDividend { get; set; }

        /// <summary>
        /// 其他应付款
        /// </summary>
        public decimal? OtherPayable { get; set; }

        /// <summary>
        /// 一年内到期的非流动负债
        /// </summary>
        public decimal? NonCurrentLiabilitiesInYear { get; set; }

        /// <summary>
        /// 其他流动负债
        /// </summary>
        public decimal? OtherCurrentLiabilities { get; set; }

        /// <summary>
        /// 流动负债合计
        /// </summary>
        public decimal? TotalCurrentLiabilities { get; set; }

        /// <summary>
        /// 长期借款
        /// </summary>
        public decimal? LongLoan { get; set; }

        /// <summary>
        /// 应付债券
        /// </summary>
        public decimal? BondPayable { get; set; }

        /// <summary>
        /// 长期应付款
        /// </summary>
        public decimal? LongAcountsPayable { get; set; }

        /// <summary>
        /// 专项应付款
        /// </summary>
        public decimal? SpecialPayment { get; set; }

        /// <summary>
        /// 预计负债
        /// </summary>
        public decimal? EstimatedLiabilities { get; set; }

        /// <summary>
        /// 递延所得税负债
        /// </summary>
        public decimal? DeferredTaxLiability { get; set; }

        /// <summary>
        /// 其他非流动负债
        /// </summary>
        public decimal? OtherNonCurrentLiabilities { get; set; }

        /// <summary>
        /// 非流动负债合计
        /// </summary>
        public decimal TotalNonNurrentLiabilities { get; set; }

        /// <summary>
        /// 负债合计
        /// </summary>
        public decimal TotalLiabilities { get; set; }

        /// <summary>
        /// 实收资本(或股本)
        /// </summary>
        public decimal? PaidCapital { get; set; }

        /// <summary>
        /// 资本公积
        /// </summary>
        public decimal? CapitalReserve { get; set; }

        /// <summary>
        /// 减:库存股
        /// </summary>
        public decimal? Stock { get; set; }

        /// <summary>
        /// 盈余公积
        /// </summary>
        public decimal? SurplusReserve { get; set; }

        /// <summary>
        /// 未分配利润
        /// </summary>
        public decimal? NoProfit { get; set; }

        /// <summary>
        /// 所有者权益合计
        /// </summary>
        public decimal TotalOwnersEquity { get; set; }

        /// <summary>
        /// 负债和所有者权益合计
        /// </summary>
        public decimal TotalLiabilitiesCapital { get; set; }
    }
}
