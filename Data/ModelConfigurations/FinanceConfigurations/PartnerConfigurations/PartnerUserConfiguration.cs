namespace Data.ModelConfigurations.FinanceConfigurations.PartnerConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.Partners;

    public class PartnerUserConfiguration : EntityTypeConfiguration<PartnerUser>
    {
        public PartnerUserConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name).IsRequired();
            Property(m => m.PartnerId).IsRequired();

            Ignore(m => m.Pwd);
            Ignore(m => m.LockoutEnabled);
            Ignore(m => m.UserType);
            Property(m => m.CreatedDate);
            HasRequired(m => m.AppUser);

            ToTable("FANC_PartnerUser");
        }
    }
}
