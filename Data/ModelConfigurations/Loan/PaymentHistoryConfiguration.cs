namespace Data.ModelConfigurations.Loan
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class PaymentHistoryConfiguration : EntityTypeConfiguration<PaymentHistory>
    {
        public PaymentHistoryConfiguration()
        {
            HasKey(m => m.Id);
            ////Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.LoanId);
            Property(m => m.ScheduledPaymentPrincipal);
            Property(m => m.ScheduledPaymentInterest);
            Property(m => m.ActualPaymentPrincipal);
            Property(m => m.ActualPaymentInterest);
            Property(m => m.ActualDatePayment);
            Property(m => m.ScheduledDatePayment);
            Property(m => m.PaymentTypes).HasMaxLength(2);
            Property(m => m.CreateDate).IsRequired();

            ToTable("LOAN_PaymentHistory");
        }
    }
}
