namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System.Collections.Generic;
    using Datagram;
    using Datagram.LoanDatagrams;

    /// <summary>
    /// 信贷业务信息文件
    /// </summary>
    public class LoanDatagramFile : AbsDatagramFile
    {
        public LoanDatagramFile(string serialNumber) : base(serialNumber)
        {
            Datagrams = new List<AbsDatagram>
            {
                // 贷款业务信息采集报文
                new LoanBusinessInfoDatagram(),

                // 担保业务信息采集报文
                new GuaranteeBusinessInfoDatagram(),

                // 欠息信息采集报文
                new DebitInterestInfoDatagram()
            };
        }

        public override DatagramFileType Type
        {
            get
            {
                return DatagramFileType.信贷业务信息文件;
            }
        }

        /// <summary>
        /// 贷款业务信息采集报文
        /// </summary>
        public LoanBusinessInfoDatagram LoanBusinessInfo { get; set; }

        /// <summary>
        /// 担保业务信息采集报文
        /// </summary>
        public GuaranteeBusinessInfoDatagram GuaranteeBusinessInfo { get; set; }

        /// <summary>
        /// 欠息信息采集报文
        /// </summary>
        public DebitInterestInfoDatagram DebitInterestInfo { get; set; }

        public override ICollection<AbsDatagram> Datagrams { get; protected set; }
    }
}
