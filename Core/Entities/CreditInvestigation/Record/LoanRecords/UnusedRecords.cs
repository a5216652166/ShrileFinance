namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;

    public class UnusedRecords : AbsRecord
    {
        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
