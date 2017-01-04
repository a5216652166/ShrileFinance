namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Produce;

    /// <summary>
    /// 产品实体
    /// </summary>
    public class ProduceConfigration : EntityTypeConfiguration<Produce>
    {
        public ProduceConfigration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Code).IsRequired().HasMaxLength(50);
            Property(m => m.Name).IsRequired().HasMaxLength(200);
            Property(m => m.InterestRate);
            Property(m => m.CostRate);
            Property(m => m.RepaymentMethod);
            Property(m => m.MinFinancingRatio);
            Property(m => m.MaxFinancingRatio);
            Property(m => m.FinalRatio);
            Property(m => m.FinancingPeriods);
            Property(m => m.RepaymentInterval);
            Property(m => m.CustomerBailRatio);
            Property(m => m.Remarks).HasMaxLength(200);
            Property(m => m.CreatedDate);

            HasMany(m => m.FinancingItems).WithOptional()
                .Map(m => m.MapKey("ProduceId"))
                .WillCascadeOnDelete();

            ToTable("PROD_Produce");
        }
    }
}
