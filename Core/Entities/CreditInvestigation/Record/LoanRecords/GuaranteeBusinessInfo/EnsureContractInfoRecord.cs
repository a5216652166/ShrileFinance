namespace Core.Entities.CreditInvestigation.Record.LoanRecords
{
    using System.Collections.Generic;
    using Segment;
    using Segment.CreditMessage;

    /// <summary>
    /// 保证合同信息记录
    /// </summary>
    public class EnsureContractInfoRecord : AbsRecord
    {
        public EnsureContractInfoRecord() : base()
        {
            Segments = new List<AbsSegment>()
            {
                // 基础段
                //new GuaranteeBase(),

                // 保证合同信息段
                //new Guarantee()
            };
        }


        /// <summary>
        /// 基础段
        /// </summary>
        public GuaranteeBase Base { get; set; }

        /// <summary>
        /// 保证合同信息段
        /// </summary>
        public Guarantee GuaranteeInfo { get; set; }

        public override ICollection<AbsSegment> Segments { get; protected set; }
    }
}
