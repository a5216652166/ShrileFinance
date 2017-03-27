namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.Partners;

    public class PartnerConfiguration : EntityTypeConfiguration<Partner>
    {
        public PartnerConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Name).IsRequired().HasMaxLength(50);
            Property(m => m.LineOfCredit);
            Property(m => m.AmountOfBail);
            Property(m => m.Address).HasMaxLength(200);
            Property(m => m.ProxyArea).HasMaxLength(200);
            Property(m => m.VehicleManage).HasMaxLength(200);
            Property(m => m.ControllerName).HasMaxLength(50);
            Property(m => m.ControllerIdentity).HasMaxLength(50);
            Property(m => m.ControllerPhone).HasMaxLength(50);
            Property(m => m.DateCreated);
            Property(m => m.Remarks).HasMaxLength(200);

            HasMany(m => m.Produces).WithMany()
                .Map(m => m.MapLeftKey("PartnerId")
                .MapRightKey("ProduceId")
                .ToTable("CRET_PartnerProduce"));
            HasMany(m => m.Approvers).WithMany()
                .Map(m => m.MapLeftKey("PartnerId")
                .MapRightKey("ApproverId")
                .ToTable("CRET_PartnerApprover"));
            HasMany(m => m.Accounts).WithMany()
                .Map(m => m.MapLeftKey("PartnerId")
                .MapRightKey("AccountId")
                .ToTable("CRET_PartnerAccount"));

            ToTable("CRET_Partner");
        }
    }
}
