namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
    using System;
    using System.Collections.Generic;
    using Segment;

    /// <summary>
    /// 事业单位收入支出表信息记录
    /// </summary>
    public class InstitutionIncomeExpenditureRecord : AbsRecord
    {
        public InstitutionIncomeExpenditureRecord()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
