namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Flow;

    public class FormRoleConfiguration : EntityTypeConfiguration<FormRole>
    {
        public FormRoleConfiguration()
        {
            HasKey(m => new { m.RoleId, m.FormId });

            Property(m => m.RoleId).IsRequired();
            Property(m => m.FormId).IsRequired();

            HasRequired(m => m.Role).WithMany()
                .WillCascadeOnDelete();
            HasRequired(m => m.Form).WithMany(m => m.Roles)
                .WillCascadeOnDelete();

            ToTable("FLOW_FormRole");
        }
    }
}
