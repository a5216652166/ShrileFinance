namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Flow;

    public class NodeConfiguration : EntityTypeConfiguration<Node>
    {
        public NodeConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).IsRequired().HasMaxLength(40);
            Property(m => m.FlowId);
            Property(m => m.RoleId);

            HasRequired(m => m.Flow).WithMany(m => m.Nodes);
            HasOptional(m => m.Role).WithMany();

            ToTable("FLOW_Node");
        }
    }
}
