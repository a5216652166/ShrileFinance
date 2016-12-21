namespace Data.ModelConfigurations.CreditInvestigation.Segment.CreditMessage
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class LoanSegmentConfiguration : EntityTypeConfiguration<LoanSegment>
    {
        public LoanSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.借据编号).HasMaxLength(60);
            Property(m => m.Principle).HasMaxLength(20);
            Property(m => m.Balance).HasMaxLength(20);
            Property(m => m.SpecialDate).HasMaxLength(8);
            Property(m => m.MatureDate).HasMaxLength(8);
            Property(m => m.LoanBusinessTypes).HasMaxLength(1);
            Property(m => m.LoanForm).HasMaxLength(1);
            Property(m => m.LoanNature).HasMaxLength(1);
            Property(m => m.LoansTo).HasMaxLength(5);
            Property(m => m.LoanTypes).HasMaxLength(2);
            Property(m => m.FourCategoryAssetsClassification).HasMaxLength(2);
            Property(m => m.FiveCategoryAssetsClassification).HasMaxLength(1);

            ToTable("CIDG_LoanSegment");
        }
    }
}
