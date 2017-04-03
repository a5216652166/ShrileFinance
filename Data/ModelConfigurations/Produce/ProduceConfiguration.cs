namespace Data.ModelConfigurations.Produce
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Produce;

    public class ProduceConfiguration : EntityTypeConfiguration<Produce>
    {
        public ProduceConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Code).IsRequired().HasMaxLength(80).HasUniqueIndexAnnotation();
            Property(m => m.ProduceType).HasMaxLength(80);
            Property(m => m.Rate).HasPrecision(18, 12);
            Property(m => m.Periods);
            Property(m => m.PeriodsPerpayment);
            Property(m => m.CustomerBailRatio).HasPrecision(18, 8);
            Property(m => m.CustomerCostRatio).HasPrecision(18, 8);
            Property(m => m.CostRate).HasPrecision(18, 12);
            Property(m => m.PartnersCommissionRatio).HasPrecision(18, 8);
            Property(m => m.EmployeeCommissionRatio).HasPrecision(18, 8);

            HasMany(m => m.PrincipalRatios)
                .WithRequired(m => m.Produce)
                .WillCascadeOnDelete();

            ToTable("PROD_Produce");
        }
    }
}
