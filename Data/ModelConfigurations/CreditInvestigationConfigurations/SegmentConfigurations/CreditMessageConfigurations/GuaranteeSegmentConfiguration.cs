namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.CreditMessageConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class GuaranteeSegmentConfiguration : EntityTypeConfiguration<GuaranteeSegment>
    {
        public GuaranteeSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.保证合同编号).HasMaxLength(60);
            Property(m => m.Name).HasMaxLength(80);
            Property(m => m.CreditcardCode).HasMaxLength(16);
            Property(m => m.Margin).HasMaxLength(20);
            Property(m => m.SigningDate).HasMaxLength(8);
            Property(m => m.GuaranteeForm).HasMaxLength(1);
            Property(m => m.EffectiveState).HasMaxLength(1);

            ToTable("CIDG_GuaranteeSegment");
        }
    }
}
