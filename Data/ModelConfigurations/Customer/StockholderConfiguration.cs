namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    public class StockholderConfiguration : EntityTypeConfiguration<Stockholder>
    {
        public StockholderConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.ShareholdersType).IsRequired().HasMaxLength(1);
            Property(m => m.ShareholdersName).IsRequired().HasMaxLength(80);
            Property(m => m.SharesProportion).IsRequired().HasPrecision(10, 2);

            Property(m => m.RegistraterType).HasMaxLength(2);
            Property(m => m.RegistraterCode).HasMaxLength(20);
            Property(m => m.OrganizateCode).HasMaxLength(10);
            Property(m => m.InstitutionCreditCode).HasMaxLength(18);

            Property(m => m.CertificateType).HasMaxLength(2);
            Property(m => m.CertificateCode).HasMaxLength(20);

            HasMany(m => m.FamilyMembers).WithOptional().Map(m => m.MapKey("StockholderId"));

            ToTable("CUST_Stockholder");
        }
    }
}
