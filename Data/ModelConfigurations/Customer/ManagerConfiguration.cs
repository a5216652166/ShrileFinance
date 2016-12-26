namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    public class ManagerConfiguration : EntityTypeConfiguration<Manager>
    {
        public ManagerConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name).IsRequired().HasMaxLength(80);
            Property(m => m.Type).IsRequired().HasMaxLength(1);
            Property(m => m.CertificateType).IsRequired().HasMaxLength(2);
            Property(m => m.CertificateCode).IsRequired().HasMaxLength(20);

            HasMany(m => m.FamilyMembers).WithOptional().Map(m => m.MapKey("ManagerId"));

            ToTable("CUST_Manager");
        }
    }
}
