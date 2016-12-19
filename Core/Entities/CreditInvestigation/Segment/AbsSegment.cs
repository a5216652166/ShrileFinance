namespace Core.Entities.CreditInvestigation.Segment
{
    using System;
    using System.Text;

    public abstract class AbsSegment : Entity
    {
        public void Packaging(StringBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
