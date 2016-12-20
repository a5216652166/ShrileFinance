using System;
namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.Concern
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern;

    /// <summary>
    /// 大事件
    /// </summary>
    class BigEventSegmentConfiguration: EntityTypeConfiguration<BigEventSegment>
    {
        public BigEventSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.信息类别).HasMaxLength(1);
            Property(m => m.BigEventNumber).HasMaxLength(60);
            Property(m => m.BigEventDescription).HasMaxLength(250);

            ToTable("CIDG_BigEventSegment");
        }
    }
}
