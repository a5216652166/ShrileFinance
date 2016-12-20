namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.CreditMessage
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
            Property(m => m.信息类别).HasMaxLength(1);
            Property(m => m.金融机构代码).HasMaxLength(11);
            Property(m => m.LoanCardCode).HasMaxLength(16);
            Property(m => m.CreditContractCode).HasMaxLength(60);
            Property(m => m.信息记录操作类型).HasMaxLength(1);
            Property(m => m.CreateDate).HasMaxLength(8);
            Property(m => m.信息记录跟踪编号).HasMaxLength(20);

            ToTable("CIDG_CreditBaseSegment");
        }
    }
}
