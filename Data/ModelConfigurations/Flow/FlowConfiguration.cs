namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Flow;

    public class FlowConfiguration : EntityTypeConfiguration<Flow>
    {
        public FlowConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).IsRequired().HasMaxLength(40);

            ToTable("FLOW_WorkFlow");
        }
    }
}
