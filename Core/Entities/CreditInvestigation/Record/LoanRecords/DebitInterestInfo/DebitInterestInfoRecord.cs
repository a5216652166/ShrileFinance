using System;
using System.Collections.Generic;
using Core.Entities.CreditInvestigation.Segment;

namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    /// <summary>
    /// 欠息信息记录
    /// </summary>
    public class DebitInterestInfoRecord : AbsRecord
    {
        public override ICollection<AbsSegment> Segments
        {
            get
            {
                throw new NotImplementedException();
            }

            protected set
            {
                throw new NotImplementedException();
            }
        }
    }
}
