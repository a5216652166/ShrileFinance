namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Loan;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 事业单位收入支出表信息记录
    /// </summary>
    public class InstitutionIncomeExpenditureRecord : AbsRecord
    {
        public InstitutionIncomeExpenditureRecord(CreditContract credit) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph()
            };

            // 事业单位收入支出表段
            foreach (var item in credit.Organization.FinancialAffairs.IncomeExpenditur)
            {
                Segments.Add(new IncomeExpenditureParagraph());
            }
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
