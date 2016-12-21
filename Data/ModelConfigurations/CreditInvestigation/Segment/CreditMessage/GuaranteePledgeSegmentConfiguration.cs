namespace Data.ModelConfigurations.CreditInvestigation.Segment.CreditMessage
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class GuaranteePledgeSegmentConfiguration : EntityTypeConfiguration<GuaranteePledgeSegment>
    {
        public GuaranteePledgeSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.质押合同编号).HasMaxLength(60);
            Property(m => m.PledgeNumber).HasMaxLength(2);
            Property(m => m.Name).HasMaxLength(80);
            Property(m => m.CreditcardCode).HasMaxLength(16);
            Property(m => m.CollateralValue).HasMaxLength(20);
            Property(m => m.SigningDate).HasMaxLength(8);
            Property(m => m.PledgeType).HasMaxLength(1);
            Property(m => m.Margin).HasMaxLength(20);
            Property(m => m.EffectiveState).HasMaxLength(1);

            ToTable("CIDG_GuaranteePledgeSegment");
        }
    }
}
