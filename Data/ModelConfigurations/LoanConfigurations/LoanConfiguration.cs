namespace Data.ModelConfigurations.LoanConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class LoanConfiguration : EntityTypeConfiguration<Loan>
    {
        public LoanConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Principle);
            Property(m => m.SpecialDate);
            Property(m => m.MatureDate);
            Property(m => m.InterestRate);
            Property(m => m.FourCategoryAssetsClassification).IsOptional();
            Property(m => m.FiveCategoryAssetsClassification);
            Property(m => m.ContractNumber).IsRequired().HasMaxLength(128);
            Property(m => m.Status);
            Property(m => m.LoanBusinessTypes).HasMaxLength(1);
            Property(m => m.LoanForm).HasMaxLength(1);
            Property(m => m.LoanNature).HasMaxLength(1);
            Property(m => m.LoansTo).HasMaxLength(5);
            Property(m => m.LoanTypes).HasMaxLength(2);

            HasMany(m => m.Payments).WithRequired()
                .HasForeignKey(m => m.LoanId);

            ToTable("CILN_Loan");
        }
    }
}
