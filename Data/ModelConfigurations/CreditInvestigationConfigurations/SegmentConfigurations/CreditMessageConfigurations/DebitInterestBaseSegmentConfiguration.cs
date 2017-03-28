namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.CreditMessageConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class DebitInterestBaseSegmentConfiguration : EntityTypeConfiguration<DebitInterestBaseSegment>
    {
        public DebitInterestBaseSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.信息记录长度).HasMaxLength(4);
            Property(m => m.LoanCardCode).HasMaxLength(16);
            Property(m => m.业务发生日期).HasMaxLength(8);

            ToTable("CIDG_DebitInterestBaseSegment");
        }
    }
}
