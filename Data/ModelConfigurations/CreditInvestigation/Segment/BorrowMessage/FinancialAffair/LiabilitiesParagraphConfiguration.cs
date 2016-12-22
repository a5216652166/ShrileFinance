using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    public class LiabilitiesParagraphConfiguration : EntityTypeConfiguration<LiabilitiesParagraph>
    {
        public LiabilitiesParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.MonetaryFund).HasMaxLength(20);
            Property(m => m.TransactionAssets).HasMaxLength(20);
            Property(m => m.NoteReceivable).HasMaxLength(20);
            Property(m => m.AccountsReceivable).HasMaxLength(20);
            Property(m => m.AdvancePayment).HasMaxLength(20);
            Property(m => m.InterestReceivable).HasMaxLength(20);
            Property(m => m.DividendsReceivable).HasMaxLength(20);
            Property(m => m.OtherReceivables).HasMaxLength(20);
            Property(m => m.Inventory).HasMaxLength(20);
            Property(m => m.NonCurrentAssetsInYear).HasMaxLength(20);
            Property(m => m.OtherCurrentAssets).HasMaxLength(20);
            Property(m => m.TotalCurrentAssets).HasMaxLength(20);
            Property(m => m.CanSaleAsset).HasMaxLength(20);
            Property(m => m.MaturityInvestment).HasMaxLength(20);
            Property(m => m.LongEquity).HasMaxLength(20);
            Property(m => m.LongReceivables).HasMaxLength(20);
            Property(m => m.InvestmentRealEstate).HasMaxLength(20);
            Property(m => m.FixedAssets).HasMaxLength(20);
            Property(m => m.ConstructionProject).HasMaxLength(20);
            Property(m => m.EngineeringMaterials).HasMaxLength(20);
            Property(m => m.FixedAssetsLiquidation).HasMaxLength(20);
            Property(m => m.ProductiveBiologicalAssets).HasMaxLength(20);
            Property(m => m.OilGasAssets).HasMaxLength(20);
            Property(m => m.IntangibleAssets).HasMaxLength(20);
            Property(m => m.DevelopmentExpenditure).HasMaxLength(20);
            Property(m => m.Goodwill).HasMaxLength(20);
            Property(m => m.LongArepaidExpenses).HasMaxLength(20);
            Property(m => m.DeferredTaxAssets).HasMaxLength(20);
            Property(m => m.OtherNonCurrentAssets).HasMaxLength(20);
            Property(m => m.TotalNonCurrentAssets).HasMaxLength(20);
            Property(m => m.TotalAssets).HasMaxLength(20);
            Property(m => m.ShortLoan).HasMaxLength(20);
            Property(m => m.TransactionalFinancialLiabilities).HasMaxLength(20);
            Property(m => m.NotesPayable).HasMaxLength(20);
            Property(m => m.AccountsPayable).HasMaxLength(20);
            Property(m => m.AccountsAdvance).HasMaxLength(20);
            Property(m => m.InterestPayable).HasMaxLength(20);
            Property(m => m.EmployeesSalary).HasMaxLength(20);
            Property(m => m.PayTax).HasMaxLength(20);
            Property(m => m.PayDividend).HasMaxLength(20);
            Property(m => m.OtherPayable).HasMaxLength(20);
            Property(m => m.NonCurrentLiabilitiesInYear).HasMaxLength(20);
            Property(m => m.OtherCurrentLiabilities).HasMaxLength(20);
            Property(m => m.TotalCurrentLiabilities).HasMaxLength(20);
            Property(m => m.LongLoan).HasMaxLength(20);
            Property(m => m.BondPayable).HasMaxLength(20);
            Property(m => m.LongAcountsPayable).HasMaxLength(20);
            Property(m => m.SpecialPayment).HasMaxLength(20);
            Property(m => m.EstimatedLiabilities).HasMaxLength(20);
            Property(m => m.DeferredTaxLiability).HasMaxLength(20);
            Property(m => m.OtherNonCurrentLiabilities).HasMaxLength(20);
            Property(m => m.TotalNonNurrentLiabilities).HasMaxLength(20);
            Property(m => m.TotalLiabilities).HasMaxLength(20);
            Property(m => m.PaidCapital).HasMaxLength(20);
            Property(m => m.CapitalReserve).HasMaxLength(20);
            Property(m => m.Stock).HasMaxLength(20);
            Property(m => m.SurplusReserve).HasMaxLength(20);
            Property(m => m.NoProfit).HasMaxLength(20);
            Property(m => m.TotalOwnersEquity).HasMaxLength(20);
            Property(m => m.TotalLiabilitiesCapital).HasMaxLength(20);

            ToTable("CIDG_LiabilitiesParagraph");
        }
    }
}
