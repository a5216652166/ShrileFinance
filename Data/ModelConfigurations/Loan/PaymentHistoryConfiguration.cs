namespace Data.ModelConfigurations.Loan
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class PaymentHistoryConfiguration : EntityTypeConfiguration<PaymentHistory>
    {
        public PaymentHistoryConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.LoanId);
            Property(m => m.ScheduledPaymentPrincipal);
            Property(m => m.ScheduledPaymentInterest);
            Property(m => m.ActualPaymentPrincipal);
            Property(m => m.ActualPaymentInterest);
            Property(m => m.DatePayment);
            Property(m => m.PaymentTypes).HasMaxLength(2);
            //Property(m => m.Hidden).IsRequired();
            Ignore(m => m.Hidden);

            ToTable("LOAN_PaymentHistory");
        }
    }
}
