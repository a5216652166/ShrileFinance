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

            //Map<LoanBusinessInfoDatagram>(m => m.Requires("Type").HasValue(DatagramTypeEnum.贷款业务信息采集报文));

            HasMany(m => m.Segments);

            ToTable("CIDG_Record");
        }
    }
}
