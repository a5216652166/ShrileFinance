namespace Data.ModelConfigurations.FinanceConfigurations.FinanceConfiguration
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

            Property(m => m.CreditAccountName).HasMaxLength(null);

            Property(m => m.CreditBankName).HasMaxLength(40);

            Property(m => m.CreditBankCard).HasMaxLength(40);

            Property(m => m.ContactJson).HasMaxLength(800);

            Property(m => m.CustomerAccountName).HasMaxLength(null);

            Property(m => m.CustomerBankName).HasMaxLength(40);

            Property(m => m.CustomerBankCard).HasMaxLength(40);

            Property(m => m.GuarantorName1).HasMaxLength(20);
            Property(m => m.GuarantorNo1).HasMaxLength(20);
            Property(m => m.GuarantorName2).HasMaxLength(20);
            Property(m => m.GuarantorNo2).HasMaxLength(20);

            ToTable("FANC_FinanceExtension");
        }
    }
}
