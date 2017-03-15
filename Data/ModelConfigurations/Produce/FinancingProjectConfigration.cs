namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Produce;

    /// <summary>
    /// 融资项目实体
    /// </summary>
    public class FinancingProjectConfigration : EntityTypeConfiguration<FinancingProject>
    {
        public FinancingProjectConfigration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name).IsRequired().HasMaxLength(50);
            Property(m => m.IsFinancing);

            ToTable("PROD_FinancingProject");
        }
    }
}
