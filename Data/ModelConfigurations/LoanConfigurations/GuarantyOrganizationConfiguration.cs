namespace Data.ModelConfigurations.LoanConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantyOrganizationConfiguration : EntityTypeConfiguration<GuarantorOrganization>
    {
        public GuarantyOrganizationConfiguration()
        {
            Property(m => m.CreditcardCode).IsRequired().HasMaxLength(16);
        }
    }
}
