namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    /// <summary>
    /// 贷款业务信息采集报文
    /// </summary>
    public class LoanBusinessInfoDatagram : Datagram
    {
        public LoanBusinessInfoDatagram() : base()
        {
            ////Records = new List<AbsRecord>() {
            ////    // 贷款业务合同信息记录
            ////    new LoanContractInfoRecord(),

            ////    // 贷款业务借据信息记录
            ////    new LoanIousInfoRecord(),

            ////    // 贷款业务还款信息记录
            ////    new LoanRepayInfoRecord()
            ////};
        }

        public override DatagramTypeEnum Type => DatagramTypeEnum.贷款业务信息采集报文;
    }
}
