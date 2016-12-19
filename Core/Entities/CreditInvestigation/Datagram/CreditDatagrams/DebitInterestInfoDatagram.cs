namespace Core.Entities.CreditInvestigation.Datagram.CreditDatagrams
{
    /// <summary>
    /// 欠息信息采集报文
    /// </summary>
    class DebitInterestInfoDatagram : AbsDatagram
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