namespace Core.Entities.Finance
{
    /// <summary>
    /// 融资扩展
    /// </summary>
    public class FinanceExtension : Entity
    {
        /// <summary>
        /// 放款主体
        /// </summary>
        public string LoanPrincipal { get; set; }

        /// <summary>
        /// 放款账户
        /// </summary>
        public string CreditAccountName { get; set; }

        /// <summary>
        /// 放款账户开户行
        /// </summary>
        public string CreditBankName { get; set; }

        /// <summary>
        /// 放款账户卡号
        /// </summary>
        public string CreditBankCard { get; set; }

        /// <summary>
        /// 合同Json
        /// </summary>
        public string ContactJson { get; set; }

        /// <summary>
        /// 还款账户
        /// </summary>
        public string CustomerAccountName { get; set; }

        /// <summary>
        /// 还款账户开户行
        /// </summary>
        public string CustomerBankName { get; set; }

        /// <summary>
        /// 还款账户卡号
        /// </summary>
        public string CustomerBankCard { get; set; }
    }
}
