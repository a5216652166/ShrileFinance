namespace Data.ModelConfigurations.LoanConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantorConfiguration : EntityTypeConfiguration<Guarantor>
    {
        public GuarantorConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name).IsRequired().HasMaxLength(80);

            Map<GuarantorOrganization>(t => t.Requires("Type").HasValue("GuarantyOrganization"));
            Map<GuarantorPerson>(t => t.Requires("Type").HasValue("GuarantyPerson"));

            ToTable("CILN_Guarantor");
        }
    }
}
