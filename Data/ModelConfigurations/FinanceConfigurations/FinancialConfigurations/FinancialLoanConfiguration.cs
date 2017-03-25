namespace Data.ModelConfigurations.FinanceConfigurations.FinancialConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance.Financial;

    public class FinancialLoanConfiguration : EntityTypeConfiguration<FinancialLoan>
    {
        public FinancialLoanConfiguration()
        {
            HasKey(m => m.Id);

            Property(m=>m.LoanNum).IsRequired().HasMaxLength(20);
            Property(m => m.LoanDate).IsRequired();
            Property(m => m.RepayDate).IsRequired();
            Property(m => m.State).IsRequired();

            HasRequired(m => m.NewProduce);

            HasMany(m => m.FinancialItem).WithOptional().Map(m => m.MapKey("FinancialLoanId"));

            ToTable("FANC_FinancialLoan");
        }
    }
}

