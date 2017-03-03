namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Process;

    public class ProcessConfiguration : EntityTypeConfiguration<Flow>
    {
        public ProcessConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).IsRequired().HasMaxLength(40);

            ToTable("FLOW_WorkFlow");
        }
    }
}
