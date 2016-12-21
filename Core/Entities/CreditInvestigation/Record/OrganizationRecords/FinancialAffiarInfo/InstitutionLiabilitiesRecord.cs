namespace Core.Entities.CreditInvestigation.Record.OrganizationRecords.FinancialAffiarInfo
{
    using System.Collections.Generic;
    using Loan;
    using Segment;
    using Segment.BorrowMessage.FinancialAffair;

    /// <summary>
    /// 事业单位资产负债表信息记录
    /// </summary>
    public class InstitutionLiabilitiesRecord : AbsRecord
    {
        public InstitutionLiabilitiesRecord(CreditContract credit) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new BaseParagraph()
            };

            // 事业单位资产负债表信息记录
            foreach (var item in credit.Organization.FinancialAffairs.InstitutionLiabilities)
            {
                Segments.Add(new InstitutionLiabilitiesParagraph());
            }
        }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.事业单位资产负债表信息记录;
            }
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
