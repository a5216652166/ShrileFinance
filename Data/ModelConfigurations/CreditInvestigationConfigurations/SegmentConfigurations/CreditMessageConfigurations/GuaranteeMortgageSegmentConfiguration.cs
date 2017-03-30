namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.CreditMessageConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class GuaranteeMortgageSegmentConfiguration : EntityTypeConfiguration<GuaranteeMortgageSegment>
    {
        public GuaranteeMortgageSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.抵押合同编号).HasMaxLength(60);
            Property(m => m.MortgageNumber).HasMaxLength(2);
            Property(m => m.Name).HasMaxLength(80);
            Property(m => m.CreditcardCode).HasMaxLength(16);
            Property(m => m.AssessmentValue).HasMaxLength(20);
            Property(m => m.AssessmentDate).HasMaxLength(8);
            Property(m => m.AssessmentName).HasMaxLength(80);
            Property(m => m.AssessmentOrganizationCode).HasMaxLength(10);
            Property(m => m.SigningDate).HasMaxLength(8);
            Property(m => m.CollateralType).HasMaxLength(1);
            Property(m => m.Margin).HasMaxLength(20);
            Property(m => m.RegistrateAuthorit).HasMaxLength(80);
            Property(m => m.RegistrateDate).HasMaxLength(8);
            Property(m => m.CollateralInstruction).HasMaxLength(400);
            Property(m => m.EffectiveState).HasMaxLength(1);

            ToTable("CIDG_GuaranteeMortgageSegment");
        }
    }
}
