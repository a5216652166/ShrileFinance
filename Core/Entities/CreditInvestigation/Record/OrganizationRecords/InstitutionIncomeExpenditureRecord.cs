namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 事业单位收入支出表信息记录
    /// </summary>
    public class InstitutionIncomeExpenditureRecord : AbsRecord
    {
        private FinancialAffairs financial;
        private InstitutionIncomeExpenditure item;

        public InstitutionIncomeExpenditureRecord(Organization organization) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph(financial, organization, item.Type.ToString()),

                // 事业单位收入支出表段
                new IncomeExpenditureParagraph(item),
            };
        }

        public InstitutionIncomeExpenditureRecord(FinancialAffairs financial, InstitutionIncomeExpenditure item)
        {
            this.financial = financial;
            this.item = item;
        }

        public InstitutionIncomeExpenditureRecord(Organization organization, InstitutionIncomeExpenditure item) : this(organization)
        {
            this.item = item;
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.事业单位收入支出表信息记录;
            }
        }
    }
}
