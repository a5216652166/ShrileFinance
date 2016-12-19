using System;
using System.Collections.Generic;
using Core.Entities.CreditInvestigation.Segment;

namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    /// <summary>
    /// 自然人抵押合同信息记录
    /// </summary>
    public class NaturalMortgageContractInfoRecord : AbsRecord
    {

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
