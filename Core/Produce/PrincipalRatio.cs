namespace Core.Produce
{
    using System;

    public class PrincipalRatio
    {
        public Guid ProduceId { get; private set; }

        public int Period { get; private set; }

        public decimal Ratio { get; private set; }

        public decimal Factor { get; set; }

        public virtual Produce Produce { get; private set; }
    }
}