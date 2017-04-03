namespace Core.Produce
{
    using Microsoft.VisualBasic;

    public class PaymentEqualsCalculator : IPaymentCalculator
    {
        private decimal Payment(double rate, double periods, double principal, double final = 0)
        {
            var payment = Financial.Pmt(rate, periods, principal, final);

            return (decimal)payment;
        }
    }
}
