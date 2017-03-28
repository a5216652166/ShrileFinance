namespace Data.ModelConfigurations.CustomerConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 资产负债
    /// </summary>
    public class ProfitConfiguration : EntityTypeConfiguration<Profit>
    {
        public ProfitConfiguration() : base()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.AssetsimpairmentLoss).HasPrecision(18, 2);
            Property(m => m.BasicEarningsShare).HasPrecision(18, 2);
            Property(m => m.BusinessIncome).IsRequired().HasPrecision(18, 2);
            Property(m => m.DilutedEarningsShare).HasPrecision(18, 2);
            Property(m => m.EnterpriseInvestmentIncome).HasPrecision(18, 2);
            Property(m => m.FairIncome).HasPrecision(18, 2);
            Property(m => m.FinancialExpenses).IsRequired().HasPrecision(18, 2);
            Property(m => m.GrossProfit).IsRequired().HasPrecision(18, 2);
            Property(m => m.IncomeTaxExpense).HasPrecision(18, 2);
            Property(m => m.ManagementExpenses).HasPrecision(18, 2);
            Property(m => m.NetInvestmentIncome).HasPrecision(18, 2);
            Property(m => m.NetProfit).IsRequired().HasPrecision(18, 2);
            Property(m => m.NonCurrentAssetsLoss).HasPrecision(18, 2);
            Property(m => m.OperatingCost).HasPrecision(18, 2);
            Property(m => m.OperatingExpenditure).HasPrecision(18, 2);
            Property(m => m.OperatingIncome).HasPrecision(18, 2);
            Property(m => m.OperatingProfit).IsRequired().HasPrecision(18, 2);
            Property(m => m.SalesTax).HasPrecision(18, 2);
            Property(m => m.SellingExpenses).HasPrecision(18, 2);
            Property(m => m.Type).IsRequired();

            ToTable("CUST_Profit");
        }
    }
}
