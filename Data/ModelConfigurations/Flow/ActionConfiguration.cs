namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Flow;

    public class ActionConfiguration : EntityTypeConfiguration<FAction>
    {
        public ActionConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).IsRequired().HasMaxLength(40);
            Property(m => m.NodeId);
            Property(m => m.TransferId).IsOptional();
            Property(m => m.Type).IsRequired();
            Property(m => m.AllocationType);
            Property(m => m.Method).HasMaxLength(100);

            HasRequired(m => m.Node).WithMany(m => m.Actions);
            HasOptional(m => m.Transfer).WithMany();

            ToTable("FLOW_Action");
        }
    }
}
