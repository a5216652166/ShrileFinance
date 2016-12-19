namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    using System.Collections.Generic;
    using Record;
    using Record.LoanRecords;

    /// <summary>
    /// 欠息信息采集报文
    /// </summary>
    public class DebitInterestInfoDatagram : AbsDatagram
    {
        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.信贷业务信息文件;
            }
        }

        /// <summary>
        /// 欠息信息记录
        /// </summary>
        public DebitInterestInfoRecord DebitInterestInfo { get; set; }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}