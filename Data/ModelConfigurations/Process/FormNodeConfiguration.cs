namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Flow;

    public class FormNodeConfiguration : EntityTypeConfiguration<FormNode>
    {
        public FormNodeConfiguration()
        {
            HasKey(m => new { m.NodeId, m.FormId });

            Property(m => m.NodeId).IsRequired();
            Property(m => m.FormId).IsRequired();
            Property(m => m.State);
            Property(m => m.IsOpen);
            Property(m => m.IsHandler);

            HasRequired(m => m.Node).WithMany()
                .WillCascadeOnDelete();
            HasRequired(m => m.Form).WithMany(m => m.Nodes)
                .WillCascadeOnDelete();

            ToTable("FLOW_FormNode");
        }
    }
}
