namespace Data.ModelConfigurations.FinanceConfigurations.BranchOfficeConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.BranchOffices;

    public class BranchOfficeConfigurations : EntityTypeConfiguration<BranchOffice>
    {
        public BranchOfficeConfigurations()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Name).IsRequired().HasMaxLength(60);
            Property(m => m.Address).IsRequired().HasMaxLength(100);
            Property(m => m.Phone).IsRequired().HasMaxLength(20);
            Property(m => m.Fax).IsOptional().HasMaxLength(20);

            ToTable("FANC_BranchOffice");
        }
    }
}
