namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.CreditMessageConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class CreditContractAmountSegmentConfiguration : EntityTypeConfiguration<CreditContractAmountSegment>
    {
        public CreditContractAmountSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.CreditLimit).HasMaxLength(20);
            Property(m => m.CreditBalance).HasMaxLength(20);

            ToTable("CIDG_CreditContractAmountSegment");
        }
    }
}
