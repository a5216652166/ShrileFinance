namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities;

    public class AppUserConfiguration : EntityTypeConfiguration<AppUser>
    {
        public AppUserConfiguration() : base()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(50);
            ////Property(m => m.UserType).IsOptional();
        }
    }
}
