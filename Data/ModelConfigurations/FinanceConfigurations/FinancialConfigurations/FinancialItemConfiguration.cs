namespace Data.ModelConfigurations.FinanceConfigurations.FinancialConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.Financial;

    public class FinancialItemConfiguration : EntityTypeConfiguration<FinanceItem>
    {
        public FinancialItemConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Name).HasMaxLength(200).IsRequired();
            Property(m => m.Principal);
            Property(m => m.Rate);
            Property(m => m.VATamount);
            Property(m => m.InvoiceAmount);
            Property(m => m.FinancialAmount);

            ToTable("FANC_FinancialItem");
        }
    }
}
