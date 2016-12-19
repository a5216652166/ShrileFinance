namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    public class CreditContractAmount
    {
        public string 信息类别
        {
            get { return "E"; }
        }

        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 贷款合同金额
        /// </summary>
        public string CreditLimit { get; set; }

        /// <summary>
        /// 贷款余额
        /// </summary>
        public string CreditBalance { get; set; }
    }
}
