namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    using System.Collections.Generic;
    using Loan;
    using Record;
    using Record.LoanRecords;

    /// <summary>
    /// 欠息信息采集报文
    /// </summary>
    public class DebitInterestInfoDatagram : AbsDatagram
    {
        public DebitInterestInfoDatagram() : base()
        {
        }

        public DebitInterestInfoDatagram(CreditContract credit, PaymentHistory payment) : base()
        {
            // 欠息信息记录
            AddRecord(new DebitInterestInfoRecord(credit, payment));
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.欠息信息采集报文;
            }
        }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}