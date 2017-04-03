namespace Core.Produce
{
    using System;

    public class PrincipalRatio
    {
        public Guid ProduceId { get; private set; }

        public int Period { get; private set; }

        public decimal Ratio { get; private set; }

        public decimal Factor
        {
            get
            {
                var rate = Produce.Rate;
                var periods = 12;
                var principal = 10000;

                var pv = principal * (Ratio / 100);

                var payment = PaymentEqualsCalculator.Payment(rate, periods, pv);

                return Math.Round(payment, 2);
            }
        }

        public virtual Produce Produce { get; private set; }
    }
}