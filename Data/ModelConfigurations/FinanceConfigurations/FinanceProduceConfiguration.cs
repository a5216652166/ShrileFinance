namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class FinanceProduceConfiguration : EntityTypeConfiguration<FinanceProduce>
    {
        public FinanceProduceConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Money);
            Property(m => m.IsEdit);
            Property(m => m.IsFinancing);
            Property(m => m.Name);

            ToTable("FANC_FinanceProduce");
        }
    }
}
