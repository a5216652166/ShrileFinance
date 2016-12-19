﻿namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System;
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 抵押合同信息记录
    /// </summary>
    public class MortgageContractInfoRecord : AbsRecord
    {
        /// <summary>
        /// 基础段
        /// </summary>
        public GuaranteeBase Base { get; set; }

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

        /// <summary>
        /// 抵押合同信息段
        /// </summary>
        //public Guarantee GuaranteeInfo { get; set; }
    }
}
