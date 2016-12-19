namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    using System.Collections.Generic;
    using Record;
    using Record.LoanRecords;

    /// <summary>
    /// 贷款业务信息采集报文
    /// </summary>
    public class LoanBusinessInfoDatagram : AbsDatagram
    {
        public LoanBusinessInfoDatagram() : base()
        {
            Records = new List<AbsRecord>() {
                // 贷款业务合同信息记录
                new LoanContractInfoRecord(),

                // 贷款业务借据信息记录
                new LoanIousInfoRecord(),

                // 贷款业务还款信息记录
                new LoanRepayInfoRecord()
            };
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.信贷业务信息文件;
            }
        }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
