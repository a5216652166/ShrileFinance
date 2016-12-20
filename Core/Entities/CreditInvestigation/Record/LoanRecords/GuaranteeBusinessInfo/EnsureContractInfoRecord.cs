namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;
    using Loan;

    /// <summary>
    /// 保证合同信息记录
    /// </summary>
    public class EnsureContractInfoRecord : AbsRecord
    {
        public EnsureContractInfoRecord(CreditContract credit,GuarantyContract guaranty) : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                new GuaranteeBaseSegment("保证",credit.Organization.LoanCardCode,credit.Id.ToString()),

                // 保证合同信息段
                new GuaranteeSegment(guaranty.Id.ToString(),credit.Organization.LoanCardCode)
            };
        }

        public override ICollection<AbsSegment> Segments { get; protected set; }

        public override RecordTypeEnum Type
        {
            get
            {
                return RecordTypeEnum.保证合同信息记录;
            }
        }
    }
}
