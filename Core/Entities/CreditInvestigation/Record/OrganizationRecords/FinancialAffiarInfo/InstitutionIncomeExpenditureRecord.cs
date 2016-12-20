namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
    using System.Collections.Generic;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 事业单位收入支出表信息记录
    /// </summary>
    public class InstitutionIncomeExpenditureRecord : AbsRecord
    {
        public InstitutionIncomeExpenditureRecord() : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph(),

                // 事业单位收入支出表段
                new IncomeExpenditureParagraph()
            };
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
