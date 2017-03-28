namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.CreditMessageConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class CreditBaseSegmentConfiguration : EntityTypeConfiguration<CreditBaseSegment>
    {
        public CreditBaseSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.信息记录长度).HasMaxLength(4);
            Property(m => m.信息记录类型).HasMaxLength(2);
            Property(m => m.LoanCardCode).HasMaxLength(16);
            Property(m => m.CreditContractCode).HasMaxLength(60);
            Property(m => m.业务发生日期).HasMaxLength(8);

            ToTable("CIDG_CreditBaseSegment");
        }
    }
}
