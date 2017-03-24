namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class FinanceExtensionConfiguration : EntityTypeConfiguration<FinanceExtension>
    {
        public FinanceExtensionConfiguration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.LoanPrincipal).HasMaxLength(20);

            Property(m => m.CreditAccountName).HasMaxLength(20);

            Property(m => m.CreditBankName).HasMaxLength(40);

            Property(m => m.CreditBankCard).HasMaxLength(40);

            Property(m => m.ContactJson).HasMaxLength(800);

            Property(m => m.CustomerAccountName).HasMaxLength(40);

            Property(m => m.CustomerBankName).HasMaxLength(40);

            Property(m => m.CustomerBankCard).HasMaxLength(40);

            ToTable("FANC_FinanceExtension");
        }
    }
}
