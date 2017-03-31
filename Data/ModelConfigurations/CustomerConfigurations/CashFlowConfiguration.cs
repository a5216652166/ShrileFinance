namespace Data.ModelConfigurations.CustomerConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 现金流
    /// </summary>
    public class CashFlowConfiguration : EntityTypeConfiguration<CashFlow>
    {
        public CashFlowConfiguration() : base()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Type).IsRequired();
            Property(m => m.AbsorbInvestmentCash).HasPrecision(18, 2);
            Property(m => m.AccruedExpenses).HasPrecision(18, 2);
            Property(m => m.AssetImpairment).HasPrecision(18, 2);
            Property(m => m.Assetloss).HasPrecision(18, 2);
            Property(m => m.AssetsDepreciation).HasPrecision(18, 2);
            Property(m => m.BuyAssetsCash).HasPrecision(18, 2);
            Property(m => m.BuyGoodsCash).HasPrecision(18, 2);
            Property(m => m.CapitalDebt).HasPrecision(18, 2);
            Property(m => m.CashEquivalentsBeginBalance).HasPrecision(18, 2);
            Property(m => m.CashEquivalentsEndingBalance).HasPrecision(18, 2);
            Property(m => m.CashEquivalentsNetIncrease).HasPrecision(18, 2);
            Property(m => m.CashIncrease5).IsRequired().HasPrecision(18, 2);
            Property(m => m.CashInInvestmentActivities).HasPrecision(18, 2);
            Property(m => m.CorporateBondInYear).HasPrecision(18, 2);
            Property(m => m.DebtRedemption).HasPrecision(18, 2);
            Property(m => m.DeferredIncomeTaAdd).HasPrecision(18, 2);
            Property(m => m.DeferredIncomeTaxLessen).HasPrecision(18, 2);
            Property(m => m.EndingBalance).HasPrecision(18, 2);
            Property(m => m.ExchangeRateChangeCash).HasPrecision(18, 2);
            Property(m => m.FairChanges).HasPrecision(18, 2);
            Property(m => m.FinalCashBalance6).IsRequired().HasPrecision(18, 2);
            Property(m => m.FinancialExpenses).HasPrecision(18, 2);
            Property(m => m.FinancingCashInflow).HasPrecision(18, 2);
            Property(m => m.FinancingCashOutflow).HasPrecision(18, 2);
            Property(m => m.FinancingFixedAssets).HasPrecision(18, 2);
            Property(m => m.FinancingNetCash).IsRequired().HasPrecision(18, 2);
            Property(m => m.FixedAssetsScrap).HasPrecision(18, 2);
            Property(m => m.GetChildrenComponyCash).HasPrecision(18, 2);
            Property(m => m.GetFinancingCash).HasPrecision(18, 2);
            Property(m => m.GetLoanCash).HasPrecision(18, 2);
            Property(m => m.IntangibleAssetsAmortization).HasPrecision(18, 2);
            Property(m => m.Inventoryreduction).HasPrecision(18, 2);
            Property(m => m.InvestmentCashInflow).IsRequired().HasPrecision(18, 2);
            Property(m => m.InvestmentCashOutflow).HasPrecision(18, 2);
            Property(m => m.InvestmentIncomeCash).HasPrecision(18, 2);
            Property(m => m.InvestmentLosses).HasPrecision(18, 2);
            Property(m => m.InvestmentPaidCash).HasPrecision(18, 2);
            Property(m => m.LongPrepaidExpenses).HasPrecision(18, 2);
            Property(m => m.NetProfit).HasPrecision(18, 2);
            Property(m => m.OperatingActivitieCashNet).IsRequired().HasPrecision(18, 2);
            Property(m => m.OperatingActivitiesCashInflows).HasPrecision(18, 2);
            Property(m => m.OperatingActivitiesCashOutflows).HasPrecision(18, 2);
            Property(m => m.OperatingCashFlowsNet).HasPrecision(18, 2);
            Property(m => m.Other).HasPrecision(18, 2);
            Property(m => m.OtherInvestmentCash).HasPrecision(18, 2);
            Property(m => m.PayablesAdd).HasPrecision(18, 2);
            Property(m => m.PayAllTaxes).HasPrecision(18, 2);
            Property(m => m.PayCashForDividend).HasPrecision(18, 2);
            Property(m => m.PayEmployeeCash).HasPrecision(18, 2);
            Property(m => m.PayFinancingCash).HasPrecision(18, 2);
            Property(m => m.PayOperatingActivitiesCash).HasPrecision(18, 2);
            Property(m => m.PayOtherFinancingCash).HasPrecision(18, 2);
            Property(m => m.PayOtherInvestmentCash).HasPrecision(18, 2);
            Property(m => m.PrepaidExpensesLessen).HasPrecision(18, 2);
            Property(m => m.ReceivableItemLosses).HasPrecision(18, 2);
            Property(m => m.ReceiveOperatingActivitiesCash).HasPrecision(18, 2);
            Property(m => m.RecoveryAssetsCash).HasPrecision(18, 2);
            Property(m => m.RecoveryChildrenCompanyCash).HasPrecision(18, 2);
            Property(m => m.RecoveryInvestmentCash).HasPrecision(18, 2);
            Property(m => m.SaleGoodsCash).HasPrecision(18, 2);
            Property(m => m.TaxesRefunds).HasPrecision(18, 2);

            ToTable("CIOG_CashFlow");
        }
    }
}
