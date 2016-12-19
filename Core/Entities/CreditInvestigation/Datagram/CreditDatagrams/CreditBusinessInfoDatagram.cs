namespace Core.Entities.CreditInvestigation.Datagram.CreditDatagrams
{
    /// <summary>
    /// 贷款业务信息采集报文
    /// </summary>
    public class CreditBusinessInfoDatagram : AbsDatagram
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
