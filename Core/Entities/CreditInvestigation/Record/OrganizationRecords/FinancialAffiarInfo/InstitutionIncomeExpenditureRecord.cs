namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
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
                return RecordTypeEnum.事业单位收入支出表信息记录;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
