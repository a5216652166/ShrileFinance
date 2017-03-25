namespace Data.ModelConfigurations.FinanceConfigurations.PartnerConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.Partners;

    public class PartnerConfiguration : EntityTypeConfiguration<Partner>
    {
        public PartnerConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.CreatedDate).IsRequired();

            HasMany(m => m.Produces).WithOptional().Map(m => m.MapKey("PartnerId"));

            HasMany(m => m.PartnerUsers).WithOptional().Map(m => m.MapKey("PartnerId"));

            ToTable("FANC_Partner");
        }
    }
}
