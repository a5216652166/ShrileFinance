﻿namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.ConcernConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern;

    /// <summary>
    /// 关注基础段
    /// </summary>
    public class ConcernBaseSegmentConfiguration : EntityTypeConfiguration<ConcernBaseSegment>
    {
        public ConcernBaseSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.信息记录长度).HasMaxLength(4);
            Property(m => m.信息记录类型).HasMaxLength(8);
            Property(m => m.借款人名称).HasMaxLength(80);
            Property(m => m.贷款卡编码).HasMaxLength(16);
            Property(m => m.业务发生日期).HasMaxLength(8);

            ToTable("CIDG_ConcernBaseSegment");
        }
    }
}
