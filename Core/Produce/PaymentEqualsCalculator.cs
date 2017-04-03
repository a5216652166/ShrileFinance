namespace Core.Produce
{
    using Microsoft.VisualBasic;

    public class PaymentEqualsCalculator : IPaymentCalculator
    {
        public static decimal Payment(decimal rate, decimal periods, decimal principal, decimal final = 0)
        {
            var payment = Financial.Pmt((double)rate, (double)periods, (double)principal, (double)final);

            return (decimal)payment;
        }
    }
}
