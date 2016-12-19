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
        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.信贷业务信息文件;
            }
        }

        /// <summary>
        /// 保证合同信息记录
        /// </summary>
        public EnsureContractInfoRecord EnsureContractInfo { get; set; }

        /// <summary>
        /// 抵押合同信息记录
        /// </summary>
        public MortgageContractInfoRecord MortgageContractInfo { get; set; }

        /// <summary>
        /// 质押合同信息记录
        /// </summary>
        public PledgeContractInfoRecord PledgeContractInfo { get; set; }

        /// <summary>
        /// 自然人保证合同信息记录
        /// </summary>
        public NaturalEnsureContractInfoRecord NaturalEnsureContractInfo { get; set; }

        /// <summary>
        /// 自然人抵押合同信息记录
        /// </summary>
        public NaturalMortgageContractInfoRecord NaturalMortgageContractInfo { get; set; }

        /// <summary>
        /// 自然人质押合同信息记录
        /// </summary>
        public NaturalPledgeContractInfoRecord NaturalPledgeContractInfo { get; set; }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
