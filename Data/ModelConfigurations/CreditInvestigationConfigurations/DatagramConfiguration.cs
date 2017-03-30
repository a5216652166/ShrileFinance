namespace Data.ModelConfigurations.CreditInvestigationConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Datagram;

    public class DatagramConfiguration : EntityTypeConfiguration<Datagram>
    {
        public DatagramConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.DateCreated);

            HasMany(m => m.Records).WithRequired()
                .HasForeignKey(m => m.DatagramId).WillCascadeOnDelete();

            ToTable("CIDG_Datagram");
        }
    }
}
