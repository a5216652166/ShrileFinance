namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RolloverSegment : Segment
    {
        public RolloverSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public override char SegmentType => 'H';
    }
}
