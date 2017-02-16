namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities;

    public class ProcessTempDataConfiguration : EntityTypeConfiguration<ProcessTempData>
    {
        public ProcessTempDataConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.ReferenceId).IsRequired();

            Property(m => m.Data).IsRequired().HasMaxLength(400);

            ToTable("Process_ProcessTempData");
        }
    }
}
