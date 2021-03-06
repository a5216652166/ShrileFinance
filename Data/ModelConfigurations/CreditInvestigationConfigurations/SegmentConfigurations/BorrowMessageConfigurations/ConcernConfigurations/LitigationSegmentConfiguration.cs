﻿namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.ConcernConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern;

    public class LitigationSegmentConfiguration : EntityTypeConfiguration<LitigationSegment>
    {
        public LitigationSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.ChargedSerialNumber).HasMaxLength(60);
            Property(m => m.ProsecuteName).HasMaxLength(80);
            Property(m => m.Money).HasMaxLength(20);
            Property(m => m.DateTime).HasMaxLength(8);
            Property(m => m.Result).HasMaxLength(100);
            Property(m => m.Reason).HasMaxLength(300);

            ToTable("CIDG_LitigationSegment");
        }
    }
}
