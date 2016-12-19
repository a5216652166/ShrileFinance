namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    using Record.LoanRecords;

    /// <summary>
    /// 欠息信息采集报文
    /// </summary>
    public class DebitInterestInfoDatagram : AbsDatagram
    {
        public override byte Type
        {
            get
            {
                return (byte)DatagramType.信贷业务信息文件;
            }
        }

        /// <summary>
        /// 欠息信息记录
        /// </summary>
        public DebitInterestInfoRecord DebitInterestInfo { get; set; }
    }
}