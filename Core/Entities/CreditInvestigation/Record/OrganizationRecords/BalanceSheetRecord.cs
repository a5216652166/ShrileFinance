﻿namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 2007版资产负债表信息记录
    /// </summary>
    public class BalanceSheetRecord : AbsRecord
    {
        public BalanceSheetRecord(Organization organization) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph()
            };

            // 2007版资产负债表段
            foreach (var item in organization.FinancialAffairs.Liabilities)
            {
                Segments.Add(new LiabilitiesParagraph());
            }
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.资产负债表信息记录2007版;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
