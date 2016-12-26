namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords
{
    using System.Collections.Generic;
    using System.Linq;
    using Customers.Enterprise;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 2007版利润及利润分配表信息记录
    /// </summary>
    public class ProfitRecord : AbsRecord
    {
        public ProfitRecord(Organization organization, Profit item) : base()
        {
            var baseParagraph = new BaseParagraph(organization.FinancialAffairs, organization, item.Type.ToString(), Type);

            Segments = new List<AbsSegment>()
            {
                // 基础段
                baseParagraph,

                // 2007版利润及利润分配表信息记录
                new ProfitsParagraph(item)
            };

            ((BaseParagraph)Segments.First()).信息记录长度 = GetLength().ToString();
        }

        protected ProfitRecord() : base()
        {
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.利润及利润分配表信息记录2007版;
            }
        }
    }
}
