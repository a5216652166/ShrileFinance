namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Flow;

    public class LogConfiguration : EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.InstanceId);
            Property(m => m.NodeId);
            Property(m => m.ActionId);
            Property(m => m.ProcessUserId);
            Property(m => m.ProcessTime);
            Property(m => m.Content).HasMaxLength(500);
            Property(m => m.Opinion.InternalOpinion).HasMaxLength(500);
            Property(m => m.Opinion.ExnernalOpinion).HasMaxLength(500);

            HasOptional(m => m.Instance).WithMany(m => m.Logs)
                .WillCascadeOnDelete();
            HasRequired(m => m.Node).WithMany();
            HasRequired(m => m.Action).WithMany();
            HasRequired(m => m.ProcessUser).WithMany();

            ToTable("FLOW_Log");
        }
    }
}
