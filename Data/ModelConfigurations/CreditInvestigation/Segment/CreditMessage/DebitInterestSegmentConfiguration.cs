namespace Data.ModelConfigurations.CreditInvestigation.Segment.CreditMessage
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class DebitInterestSegmentConfiguration : EntityTypeConfiguration<DebitInterestSegment>
    {
        public DebitInterestSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.欠息余额).HasMaxLength(20);
            Property(m => m.欠息余额改变日期).HasMaxLength(8);

            ToTable("CIDG_DebitInterestSegment");
        }
    }
}
