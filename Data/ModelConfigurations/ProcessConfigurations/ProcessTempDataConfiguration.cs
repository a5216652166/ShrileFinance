namespace Data.ModelConfigurations.ProcessConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities;

    public class ProcessTempDataConfiguration : EntityTypeConfiguration<ProcessTempData>
    {
        public ProcessTempDataConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.InstanceId).IsRequired();
            Property(m => m.JsonData).IsRequired().HasColumnName("Data").HasMaxLength(null);

            HasRequired(m => m.Instance);

            ToTable("FLOW_InstanceData");
        }
    }
}
