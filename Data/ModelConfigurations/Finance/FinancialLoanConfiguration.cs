namespace Data.ModelConfigurations.Finance
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class FinancialLoanConfiguration : EntityTypeConfiguration<FinancialLoan>
    {
        public FinancialLoanConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.LoanDate).IsRequired();
            Property(m => m.RepayDate).IsRequired();
            Property(m => m.AssetType).IsRequired();

            HasRequired(m => m.NewProduce);
            HasRequired(m => m.FinancialItem);

            ToTable("FANC_FinancialLoan");
        }
    }
}

