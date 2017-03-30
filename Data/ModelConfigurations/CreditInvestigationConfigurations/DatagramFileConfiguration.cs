namespace Data.ModelConfigurations.CreditInvestigationConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.DatagramFile;

    public class DatagramFileConfiguration : EntityTypeConfiguration<DatagramFile>
    {
        public DatagramFileConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.SerialNumber).IsRequired().HasMaxLength(4);
            Property(m => m.DateCreated);
            Property(m => m.TraceId);

            Map<OrganizationDatagramFile>(m => m.Requires("Type").HasValue((int)DatagramFileType.机构基本信息采集报文文件));
            Map<BorrowerDatagramFile>(m => m.Requires("Type").HasValue((int)DatagramFileType.借款人基本信息文件));
            Map<LoanDatagramFile>(m => m.Requires("Type").HasValue((int)DatagramFileType.信贷业务信息文件));

            HasMany(m => m.Datagrams).WithRequired()
                .HasForeignKey(m => m.DatagramFileId).WillCascadeOnDelete();

            ToTable("CIDG_DatagramFile");
        }
    }
}
