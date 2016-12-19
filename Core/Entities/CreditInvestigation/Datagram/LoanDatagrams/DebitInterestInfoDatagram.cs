namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
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
    }
}