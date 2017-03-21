namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System;
    using System.Collections.Generic;
    using Datagram;
    using Datagram.LoanDatagrams;

    /// <summary>
    /// 信贷业务信息文件
    /// </summary>
    public class LoanDatagramFile : DatagramFile
    {
        protected LoanDatagramFile() : base()
        {
        }

        public override DatagramFileType Type => DatagramFileType.信贷业务信息文件;

        public static LoanDatagramFile Create() =>
            new LoanDatagramFile()
            {
                DateCreated = DateTime.Now,
                Datagrams = new List<Datagram>
                {
                // 贷款业务信息采集报文
                new LoanBusinessInfoDatagram(),
                new UnusedDatagram(DatagramTypeEnum.保理业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.票据贴现业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.贸易融资业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.信用证业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.保函业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.银行承兑汇票业务信息采集报文),
                new UnusedDatagram(DatagramTypeEnum.公开授信信息采集报文),

                // 担保业务信息采集报文
                new GuaranteeBusinessInfoDatagram(),
                new UnusedDatagram(DatagramTypeEnum.垫款业务信息采集报文),

                // 欠息信息采集报文
                new DebitInterestInfoDatagram()
                }
            };
    }
}
