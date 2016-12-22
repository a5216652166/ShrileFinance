namespace Data.ModelConfigurations.CreditInvestigation
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Datagram;
    //using Core.Entities.CreditInvestigation.Datagram.LoanDatagrams;

    public class DatagramConfiguration : EntityTypeConfiguration<AbsDatagram>
    {
        public DatagramConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.DateCreated);
            // Property(m => m.Type);

            //Map<LoanBusinessInfoDatagram>(m => m.Requires("Type").HasValue(DatagramTypeEnum.贷款业务信息采集报文));

            HasMany(m => m.Records);

            ToTable("CIDG_Datagram");
        }
    }
}
