using System;
namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 自然人抵押合同信息记录
    /// </summary>
    public class NaturalMortgageContractInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public GuaranteeBase Base { get; set; }

        /// <summary>
        /// 自然人抵押合同信息段
        /// </summary>
        public NaturalMortgage NaturalMortgageInfo { get; set; }


        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
