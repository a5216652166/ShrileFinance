﻿namespace Data.ModelConfigurations.CreditInvestigation.Segment.CreditMessage
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;
    class NaturalGuaranteeSegmentConfiguration : EntityTypeConfiguration<NaturalGuaranteeSegment>
    {
        public NaturalGuaranteeSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.保证合同编号).HasMaxLength(60);
            Property(m => m.Name).HasMaxLength(80);
            Property(m => m.CertificateType).HasMaxLength(1);
            Property(m => m.CertificateNumber).HasMaxLength(18);
            Property(m => m.Margin).HasMaxLength(20);
            Property(m => m.SigningDate).HasMaxLength(8);
            Property(m => m.GuaranteeForm).HasMaxLength(1);
            Property(m => m.EffectiveState).HasMaxLength(1);

            ToTable("CIDG_NaturalGuaranteeSegment");
        }
    }
}
