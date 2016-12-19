namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    /// <summary>
    /// 担保业务信息采集报文
    /// </summary>
    public class GuaranteeBusinessInfoDatagram : AbsDatagram
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
