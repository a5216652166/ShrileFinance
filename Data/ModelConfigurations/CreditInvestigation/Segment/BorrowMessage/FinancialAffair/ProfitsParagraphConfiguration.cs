namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;

    public class ProfitsParagraphConfiguration : EntityTypeConfiguration<ProfitsParagraph>
    {
        public ProfitsParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.BusinessIncome).HasMaxLength(20);
            Property(m => m.OperatingCost).HasMaxLength(20);
            Property(m => m.SalesTax).HasMaxLength(20);
            Property(m => m.SellingExpenses).HasMaxLength(20);
            Property(m => m.ManagementExpenses).HasMaxLength(20);
            Property(m => m.FinancialExpenses).HasMaxLength(20);
            Property(m => m.AssetsimpairmentLoss).HasMaxLength(20);
            Property(m => m.FairIncome).HasMaxLength(20);
            Property(m => m.NetInvestmentIncome).HasMaxLength(20);
            Property(m => m.EnterpriseInvestmentIncome).HasMaxLength(20);
            Property(m => m.OperatingProfit).HasMaxLength(20);
            Property(m => m.OperatingIncome).HasMaxLength(20);
            Property(m => m.OperatingExpenditure).HasMaxLength(20);
            Property(m => m.NonCurrentAssetsLoss).HasMaxLength(20);
            Property(m => m.GrossProfit).HasMaxLength(20);
            Property(m => m.IncomeTaxExpense).HasMaxLength(20);
            Property(m => m.NetProfit).HasMaxLength(20);
            Property(m => m.BasicEarningsShare).HasMaxLength(20);
            Property(m => m.DilutedEarningsShare).HasMaxLength(20);

            ToTable("CIDG_ProfitsParagraph");
        }
    }
}
