namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    using Core.Entities.CreditInvestigation.Record.LoanRecords;

    /// <summary>
    /// 贷款业务信息采集报文
    /// </summary>
    public class LoanBusinessInfoDatagram : AbsDatagram
    {
        public override byte Type
        {
            get
            {
                return (byte)DatagramType.信贷业务信息文件;
            }
        }

        /// <summary>
        /// 贷款业务合同信息记录
        /// </summary>
        public LoanContractInfoRecord LoanContractInfo { get; set; }

        /// <summary>
        /// 贷款业务借据信息记录
        /// </summary>
        public LoanIousInfoRecord LoanIousInfo { get; set; }

        /// <summary>
        /// 贷款业务还款信息记录
        /// </summary>
        public LoanRepayInfoRecord LoanRepayInfo { get; set; }
    }
}
