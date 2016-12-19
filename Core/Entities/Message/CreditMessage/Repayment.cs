namespace Core.Entities.Message.CreditMessage
{
    public class Repayment
    {
        public string 信息类别
        {
            get { return "G"; }
        }

        /// <summary>
        /// 借据编号
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// 还款日期
        /// </summary>
        public string DatePayment { get; set; }

        public string 还款次数 { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        public string PaymentTypes { get; set; }
    }
}
