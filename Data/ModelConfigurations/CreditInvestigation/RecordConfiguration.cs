namespace Data.ModelConfigurations.CreditInvestigation
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Record;

    public class RecordConfiguration : EntityTypeConfiguration<AbsRecord>
    {
        public RecordConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(m => m.Segments).WithRequired()
                .HasForeignKey(m => m.RecordId).WillCascadeOnDelete();

            ToTable("CIDG_Record");
        }
    }
}
