namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 财务
    /// </summary>
    public class FinancialAffairsConfiguration : EntityTypeConfiguration<FinancialAffairs>
    {
        public FinancialAffairsConfiguration() : base()
        {
            Property(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.AuditFirm).IsRequired().HasMaxLength(80);
            Property(m => m.AuditorName).IsRequired().HasMaxLength(30);
            Property(m => m.Year).IsRequired();
            Property(m => m.TypeSubdivision).IsRequired();
            Property(m => m.AuditorDate);
            HasMany(m => m.IncomeExpenditur).WithOptional().Map(m => m.MapKey("FinancialAffairsId"));
            HasMany(m => m.InstitutionLiabilities).WithOptional().Map(m => m.MapKey("FinancialAffairsId"));
            HasMany(m => m.Liabilities).WithOptional().Map(m => m.MapKey("FinancialAffairsId"));
            HasMany(m => m.Profit).WithOptional().Map(m => m.MapKey("FinancialAffairsId"));
            HasMany(m => m.CashFlow).WithOptional().Map(m => m.MapKey("FinancialAffairsId"));

            ToTable("CUST_FinancialAffairs");
        }
    }
}
