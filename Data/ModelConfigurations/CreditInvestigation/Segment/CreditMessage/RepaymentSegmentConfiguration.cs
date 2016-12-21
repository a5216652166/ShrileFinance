namespace Data.ModelConfigurations.CreditInvestigation.Segment.CreditMessage
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.CreditMessage;

    public class RepaymentSegmentConfiguration : EntityTypeConfiguration<RepaymentSegment>
    {
        public RepaymentSegmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.LoanId).HasMaxLength(60);
            Property(m => m.DatePayment).HasMaxLength(8);
            Property(m => m.还款次数).HasMaxLength(4);
            Property(m => m.PaymentTypes).HasMaxLength(2);
            Property(m => m.ActualPaymentPrincipal).HasMaxLength(20);
            
            ToTable("CIDG_RepaymentSegment");
        }
    }
}
