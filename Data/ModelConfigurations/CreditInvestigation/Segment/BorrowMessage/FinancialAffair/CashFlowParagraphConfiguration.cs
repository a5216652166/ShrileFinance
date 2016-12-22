using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    public class CashFlowParagraphConfiguration : EntityTypeConfiguration<CashFlowParagraph>
    {
        public CashFlowParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.SaleGoodsCash).HasMaxLength(20);
            Property(m => m.TaxesRefunds).HasMaxLength(20);
            Property(m => m.ReceiveOperatingActivitiesCash).HasMaxLength(20);
            Property(m => m.OperatingActivitiesCashInflows).HasMaxLength(20);
            Property(m => m.BuyGoodsCash).HasMaxLength(20);
            Property(m => m.PayEmployeeCash).HasMaxLength(20);
            Property(m => m.PayAllTaxes).HasMaxLength(20);
            Property(m => m.PayOperatingActivitiesCash).HasMaxLength(20);
            Property(m => m.OperatingActivitiesCashOutflows).HasMaxLength(20);
            Property(m => m.OperatingActivitieCashNet).HasMaxLength(20);
            Property(m => m.RecoveryInvestmentCash).HasMaxLength(20);
            Property(m => m.InvestmentIncomeCash).HasMaxLength(20);
            Property(m => m.RecoveryAssetsCash).HasMaxLength(20);
            Property(m => m.RecoveryChildrenCompanyCash).HasMaxLength(20);
            Property(m => m.OtherInvestmentCash).HasMaxLength(20);
            Property(m => m.CashInInvestmentActivities).HasMaxLength(20);
            Property(m => m.BuyAssetsCash).HasMaxLength(20);
            Property(m => m.InvestmentPaidCash).HasMaxLength(20);
            Property(m => m.GetChildrenComponyCash).HasMaxLength(20);
            Property(m => m.PayOtherInvestmentCash).HasMaxLength(20);
            Property(m => m.InvestmentCashOutflow).HasMaxLength(20);
            Property(m => m.InvestmentCashInflow).HasMaxLength(20);
            Property(m => m.AbsorbInvestmentCash).HasMaxLength(20);
            Property(m => m.GetLoanCash).HasMaxLength(20);
            Property(m => m.GetFinancingCash).HasMaxLength(20);
            Property(m => m.FinancingCashInflow).HasMaxLength(20);
            Property(m => m.DebtRedemption).HasMaxLength(20);
            Property(m => m.PayCashForDividend).HasMaxLength(20);
            Property(m => m.PayFinancingCash).HasMaxLength(20);
            Property(m => m.PayOtherFinancingCash).HasMaxLength(20);
            Property(m => m.FinancingCashOutflow).HasMaxLength(20);
            Property(m => m.FinancingNetCash).HasMaxLength(20);
            Property(m => m.ExchangeRateChangeCash).HasMaxLength(20);
            Property(m => m.CashIncrease5).HasMaxLength(20);
            Property(m => m.BeginCashBalance).HasMaxLength(20);
            Property(m => m.FinalCashBalance6).HasMaxLength(20);
            Property(m => m.NetProfit).HasMaxLength(20);
            Property(m => m.AssetImpairment).HasMaxLength(20);
            Property(m => m.AssetsDepreciation).HasMaxLength(20);
            Property(m => m.IntangibleAssetsAmortization).HasMaxLength(20);
            Property(m => m.LongPrepaidExpenses).HasMaxLength(20);
            Property(m => m.PrepaidExpensesLessen).HasMaxLength(20);
            Property(m => m.AccruedExpenses).HasMaxLength(20);
            Property(m => m.Assetloss).HasMaxLength(20);
            Property(m => m.FixedAssetsScrap).HasMaxLength(20);
            Property(m => m.FairChanges).HasMaxLength(20);
            Property(m => m.FinancialExpenses).HasMaxLength(20);
            Property(m => m.InvestmentLosses).HasMaxLength(20);
            Property(m => m.DeferredIncomeTaxLessen).HasMaxLength(20);
            Property(m => m.DeferredIncomeTaAdd).HasMaxLength(20);
            Property(m => m.Inventoryreduction).HasMaxLength(20);
            Property(m => m.ReceivableItemLosses).HasMaxLength(20);
            Property(m => m.PayablesAdd).HasMaxLength(20);
            Property(m => m.Other).HasMaxLength(20);
            Property(m => m.OperatingCashFlowsNet).HasMaxLength(20);
            Property(m => m.CapitalDebt).HasMaxLength(20);
            Property(m => m.CorporateBondInYear).HasMaxLength(20);
            Property(m => m.FinancingFixedAssets).HasMaxLength(20);
            Property(m => m.EndingBalance).HasMaxLength(20);
            Property(m => m.BeginBalance).HasMaxLength(20);
            Property(m => m.CashEquivalentsEndingBalance).HasMaxLength(20);
            Property(m => m.CashEquivalentsBeginBalance).HasMaxLength(20);
            Property(m => m.CashEquivalentsNetIncrease).HasMaxLength(20);

            ToTable("CIDG_CashFlowParagraph");
        }
    }
}
