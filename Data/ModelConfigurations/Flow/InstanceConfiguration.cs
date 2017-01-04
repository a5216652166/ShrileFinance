namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Flow;

    public class InstanceConfiguration : EntityTypeConfiguration<Instance>
    {
        public InstanceConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Title).HasMaxLength(200);
            Property(m => m.FlowId);
            Property(m => m.CurrentNodeId).IsOptional();
            Property(m => m.CurrentUserId);
            Property(m => m.StartUserId);
            Property(m => m.StartTime);
            Property(m => m.EndTime);
            Property(m => m.Status);
            Property(m => m.RootKey);

            HasRequired(m => m.Flow).WithMany();
            HasOptional(m => m.CurrentNode).WithMany();
            HasOptional(m => m.CurrentUser).WithMany();
            HasRequired(m => m.StartUser).WithMany();

            ToTable("FLOW_Instance");
        }
    }
}
