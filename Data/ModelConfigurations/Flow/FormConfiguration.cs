namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Flow;

    public class FormConfiguration : EntityTypeConfiguration<Form>
    {
        public FormConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.FlowId);
            Property(m => m.Name).IsRequired().HasMaxLength(50);
            Property(m => m.Link).IsRequired().HasMaxLength(100);
            Property(m => m.Sort);

            ToTable("FLOW_Form");
        }
    }
}
