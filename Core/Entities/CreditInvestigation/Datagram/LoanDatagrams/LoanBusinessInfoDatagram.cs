namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    using System.Collections.Generic;
    using Core.Entities.CreditInvestigation.Record.LoanRecords;
    using Record;

    /// <summary>
    /// 贷款业务信息采集报文
    /// </summary>
    public class LoanBusinessInfoDatagram : AbsDatagram
    {
        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.信贷业务信息文件;
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

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
