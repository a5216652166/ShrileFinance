namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    public class NaturalGuarantee
    {
        public string 信息类别
        {
            get { return "G"; }
        }

        /// <summary>
        /// 保证合同编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 保证人名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertificateType { get; set; }

        public string CertificateNumber { get; set; }

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
