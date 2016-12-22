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
        public LoanDatagramFile(int serialNumber) : base(serialNumber)
        {
            Datagrams = new List<AbsDatagram>
            {
                ////// 贷款业务信息采集报文
                ////new LoanBusinessInfoDatagram(),

                ////// 担保业务信息采集报文
                ////new GuaranteeBusinessInfoDatagram(),

                ////// 欠息信息采集报文
                ////new DebitInterestInfoDatagram()

                new UnusedDatagram(DatagramTypeEnum.保理业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.票据贴现业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.贸易融资业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.信用证业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.保函业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.银行承兑汇票业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.公开授信信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.垫款业务信息采集报文),
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
