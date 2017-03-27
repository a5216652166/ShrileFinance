namespace Data.ModelConfigurations.FinanceConfigurations.PartnerConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.Partners;
    using Core.Interfaces;

    public class PartnerConfiguration : EntityTypeConfiguration<NewPartner>
    {
        public PartnerConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).IsRequired().HasMaxLength(40);
            Property(m => m.PrincipalPerson).IsRequired().HasMaxLength(40);
            Property(m => m.CooperationTimeStart).IsRequired();
            Property(m => m.CooperationTimeEnd).IsRequired();

            Property(m => m.IsDelete).IsRequired();
            Property(m => m.CreatedDate).IsRequired();
            HasMany(m => m.Produces).WithOptional().Map(m => m.MapKey("PartnerId"));
            HasMany(m => m.PartnerUsers).WithOptional().Map(m => m.MapKey("PartnerId"));

            ToTable("FANC_Partner");
        }
    }
}
