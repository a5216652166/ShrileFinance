namespace Data.ModelConfigurations.Produce
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Produce;

    public class PrincipalRatioConfiguration : EntityTypeConfiguration<PrincipalRatio>
    {
        public PrincipalRatioConfiguration()
        {
            HasKey(m => new { m.ProduceId, m.Period });

            Property(m => m.ProduceId);
            Property(m => m.Period);
            Property(m => m.Ratio).HasPrecision(18, 8);
            Ignore(m => m.Factor);

            ToTable("PROD_PrincipalRatio");
        }
    }
}
