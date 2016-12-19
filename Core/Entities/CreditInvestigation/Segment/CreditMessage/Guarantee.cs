namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    /// <summary>
    /// 担保
    /// </summary>
    public class Guarantee
    {
        public string 信息类别
        {
            get { return "D"; }
        }

        /// <summary>
        /// 保证合同编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 保证人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        public string CreditcardCode { get; set; }

        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 保证金额
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// 合同签订日期
        /// </summary>
        public string SigningDate { get; set; }

        /// <summary>
        /// 担保形式
        /// </summary>
        public string GuaranteeForm { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        public string EffectiveState { get; set; }
    }
}
