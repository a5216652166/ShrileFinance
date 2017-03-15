namespace Data.ModelConfigurations 
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Produce;

    /// <summary>
    /// 产品对应的融资项
    /// </summary>
    public class FinancingItemConfigration : EntityTypeConfiguration<FinancingItem>
    {
        public FinancingItemConfigration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Money);
            Property(m => m.IsEdit);

            ToTable("PROD_FinancingItem");
        }
    }
}
