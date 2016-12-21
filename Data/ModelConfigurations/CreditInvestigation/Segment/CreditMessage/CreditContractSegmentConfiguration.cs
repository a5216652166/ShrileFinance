namespace Data.ModelConfigurations.CreditInvestigation.Segment.CreditMessage
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class CreditContractSegmentConfiguration : EntityTypeConfiguration<CreditContractSegment>
    {
        public CreditContractSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.InstitutionChName).HasMaxLength(80);
            Property(m => m.EffectiveDate).HasMaxLength(8);
            Property(m => m.ExpirationDate).HasMaxLength(8);
            Property(m => m.EffectiveStatus).HasMaxLength(1);
            Property(m => m.HasGuarantee).HasMaxLength(1);

            ToTable("CIDG_CreditContractSegment");
        }
    }
}
