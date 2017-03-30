namespace Data.ModelConfigurations.CustomerConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 资产负债
    /// </summary>
    public class LiabilitiesConfiguration : EntityTypeConfiguration<Liabilities>
    {
        public LiabilitiesConfiguration() : base()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Type).IsRequired();
            Property(m => m.AccountsAdvance).HasPrecision(18, 2);
            Property(m => m.AccountsPayable).HasPrecision(18, 2);
            Property(m => m.AccountsReceivable).HasPrecision(18, 2);
            Property(m => m.AdvancePayment).HasPrecision(18, 2);
            Property(m => m.BondPayable).HasPrecision(18, 2);
            Property(m => m.CanSaleAsset).HasPrecision(18, 2);
            Property(m => m.CapitalReserve).HasPrecision(18, 2);
            Property(m => m.ConstructionProject).HasPrecision(18, 2);
            Property(m => m.DeferredTaxAssets).HasPrecision(18, 2);
            Property(m => m.DeferredTaxLiability).HasPrecision(18, 2);
            Property(m => m.DevelopmentExpenditure).HasPrecision(18, 2);
            Property(m => m.DividendsReceivable).HasPrecision(18, 2);
            Property(m => m.EmployeesSalary).HasPrecision(18, 2);
            Property(m => m.EngineeringMaterials).HasPrecision(18, 2);
            Property(m => m.EstimatedLiabilities).HasPrecision(18, 2);
            Property(m => m.FixedAssets).HasPrecision(18, 2);
            Property(m => m.FixedAssetsLiquidation).HasPrecision(18, 2);
            Property(m => m.Goodwill).HasPrecision(18, 2);
            Property(m => m.IntangibleAssets).HasPrecision(18, 2);
            Property(m => m.InterestPayable).HasPrecision(18, 2);
            Property(m => m.InterestReceivable).HasPrecision(18, 2);
            Property(m => m.Inventory).HasPrecision(18, 2);
            Property(m => m.InvestmentRealEstate).HasPrecision(18, 2);
            Property(m => m.LongAcountsPayable).HasPrecision(18, 2);
            Property(m => m.LongArepaidExpenses).HasPrecision(18, 2);
            Property(m => m.LongEquity).HasPrecision(18, 2);
            Property(m => m.LongLoan).HasPrecision(18, 2);
            Property(m => m.LongReceivables).HasPrecision(18, 2);
            Property(m => m.MaturityInvestment).HasPrecision(18, 2);
            Property(m => m.MonetaryFund).HasPrecision(18, 2);
            Property(m => m.NonCurrentAssetsInYear).HasPrecision(18, 2);
            Property(m => m.NonCurrentLiabilitiesInYear).HasPrecision(18, 2);
            Property(m => m.NoProfit).HasPrecision(18, 2);
            Property(m => m.NoteReceivable).HasPrecision(18, 2);
            Property(m => m.NotesPayable).HasPrecision(18, 2);
            Property(m => m.OilGasAssets).HasPrecision(18, 2);
            Property(m => m.OtherCurrentAssets).HasPrecision(18, 2);
            Property(m => m.OtherCurrentLiabilities).HasPrecision(18, 2);
            Property(m => m.OtherNonCurrentAssets).HasPrecision(18, 2);
            Property(m => m.OtherNonCurrentLiabilities).HasPrecision(18, 2);
            Property(m => m.OtherPayable).HasPrecision(18, 2);
            Property(m => m.OtherReceivables).HasPrecision(18, 2);
            Property(m => m.PaidCapital).HasPrecision(18, 2);
            Property(m => m.PayDividend).HasPrecision(18, 2);
            Property(m => m.PayTax).HasPrecision(18, 2);
            Property(m => m.ProductiveBiologicalAssets).HasPrecision(18, 2);
            Property(m => m.ShortLoan).HasPrecision(18, 2);
            Property(m => m.SpecialPayment).HasPrecision(18, 2);
            Property(m => m.Stock).HasPrecision(18, 2);
            Property(m => m.SurplusReserve).HasPrecision(18, 2);
            Property(m => m.TotalAssets).IsRequired().HasPrecision(18, 2);
            Property(m => m.TotalCurrentAssets).IsRequired().HasPrecision(18, 2);
            Property(m => m.TotalCurrentLiabilities).HasPrecision(18, 2);
            Property(m => m.TotalLiabilities).IsRequired().HasPrecision(18, 2);
            Property(m => m.TotalLiabilitiesCapital).IsRequired().HasPrecision(18, 2);
            Property(m => m.TotalNonCurrentAssets).IsRequired().HasPrecision(18, 2);
            Property(m => m.TotalNonNurrentLiabilities).IsRequired().HasPrecision(18, 2);
            Property(m => m.TotalOwnersEquity).IsRequired().HasPrecision(18, 2);
            Property(m => m.TransactionalFinancialLiabilities).HasPrecision(18, 2);
            Property(m => m.TransactionAssets).HasPrecision(18, 2);

            ToTable("CUST_Liabilities");
        }
    }
}
