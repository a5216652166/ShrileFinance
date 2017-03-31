namespace Data.ModelConfigurations.CustomerConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    public class AssociatedEnterpriseConfiguration : EntityTypeConfiguration<AssociatedEnterprise>
    {
        public AssociatedEnterpriseConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Name).IsRequired().HasMaxLength(80);
            Property(m => m.AssociatedType).IsRequired().HasMaxLength(2);
            Property(m => m.InstitutionCreditCode).HasMaxLength(18);
            Property(m => m.OrganizateCode).HasMaxLength(10);
            Property(m => m.RegistraterCode).HasMaxLength(20);
            Property(m => m.RegistraterType).HasMaxLength(2);

            ToTable("CIOG_AssociatedEnterprise");
        }
    }
}
