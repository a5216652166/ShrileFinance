namespace Data.ModelConfigurations.CreditInvestigation
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.DatagramFile;

    public class DatagramFileConfiguration : EntityTypeConfiguration<AbsDatagramFile>
    {
        public DatagramFileConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.DateCreated);
            // Property(m => m.Type);
            Property(m => m.SerialNumber).IsRequired().HasMaxLength(4);

            HasMany(m => m.Datagrams);

            ToTable("CIDG_DatagramFile");
        }
    }
}
