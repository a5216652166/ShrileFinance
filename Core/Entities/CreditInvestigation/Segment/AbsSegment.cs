namespace Core.Entities.CreditInvestigation.Segment
{
    using System;
    using System.Text;

    public abstract class AbsSegment : Entity
    {
        public void Packaging(StringBuilder builder)
        {
            // TODO: 反射遍历属性
            throw new NotImplementedException();
        }
    }
}
