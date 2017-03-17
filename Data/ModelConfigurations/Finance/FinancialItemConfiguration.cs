namespace Data.ModelConfigurations.Finance
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class FinancialItemConfiguration : EntityTypeConfiguration<FinancialItem>
    {
        public FinancialItemConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).HasMaxLength(200).IsRequired();
            Property(m => m.Principal).IsRequired();
            Property(m => m.Rate).IsRequired();
            Property(m => m.VATamount).IsRequired();
            Property(m => m.InvoiceAmount).IsRequired();
            Property(m => m.financialAmount).IsRequired();

            ToTable("FANC_FinancialItem");
        }
    }
}
