namespace Core.Entities.CreditInvestigation.Datagram.LoanDatagrams
{
    using System.Collections.Generic;
    using Record;
    using Record.LoanRecords;

    /// <summary>
    /// 担保业务信息采集报文
    /// </summary>
    public class GuaranteeBusinessInfoDatagram : AbsDatagram
    {
        public GuaranteeBusinessInfoDatagram() : base()
        {
            Records = new List<AbsRecord>() {
                ////// 保证合同信息记录
                ////new EnsureContractInfoRecord(),

                ////// 抵押合同信息记录
                ////new MortgageContractInfoRecord(),

                ////// 质押合同信息记录
                ////new PledgeContractInfoRecord(),
                
                ////// 自然人保证合同信息记录
                ////new NaturalEnsureContractInfoRecord(),

                ////// 自然人抵押合同信息记录
                ////new NaturalMortgageContractInfoRecord(),

                ////// 自然人质押合同信息记录
                ////new NaturalPledgeContractInfoRecord()
            };
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.担保业务信息采集报文;
            }
        }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
