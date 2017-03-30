namespace Data.ModelConfigurations.LoanConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantyPersonConfiguration : EntityTypeConfiguration<GuarantorPerson>
    {
        public GuarantyPersonConfiguration()
        {
            Property(m => m.CertificateType).IsRequired().HasMaxLength(1);
            Property(m => m.CertificateNumber).IsRequired().HasMaxLength(18);
        }
    }
}
