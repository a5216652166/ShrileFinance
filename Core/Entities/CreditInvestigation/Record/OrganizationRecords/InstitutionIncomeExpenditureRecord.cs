namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 事业单位收入支出表信息记录
    /// </summary>
    public class InstitutionIncomeExpenditureRecord : AbsRecord
    {
        public InstitutionIncomeExpenditureRecord(Organization organization, InstitutionIncomeExpenditure item) : base()
        {
            var baseParagraph = new BaseParagraph(organization.FinancialAffairs, organization, item.Type.ToString());

            Segments = new List<AbsSegment>()
            {
                // 基础段
               baseParagraph,

                // 事业单位收入支出表段
                new IncomeExpenditureParagraph(item),
            };

            ((BaseParagraph)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected InstitutionIncomeExpenditureRecord() : base()
        {
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
