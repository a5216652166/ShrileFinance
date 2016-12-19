namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    public class NaturalMortgage
    {
        public string 信息类别
        {
            get { return "H"; }
        }

        /// <summary>
        /// 抵押合同编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 抵押序号
        /// </summary>
        public string MortgageNumber { get; set; }

        /// <summary>
        /// 抵押人名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertificateNumber { get; set; }

        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 抵押物评估价值
        /// </summary>
        public string AssessmentValue { get; set; }

        /// <summary>
        /// 评估日期
        /// </summary>
        public string AssessmentDate { get; set; }

        /// <summary>
        /// 评估机构名称
        /// </summary>
        public string AssessmentName { get; set; }

        /// <summary>
        /// 评估机构组织机构代码
        /// </summary>
        public string AssessmentOrganizationCode { get; set; }

        /// <summary>
        /// 合同签订日期（授信合同中的日期）
        /// </summary>
        public string SigningDate { get; set; }

        /// <summary>
        /// 抵押物种类
        /// </summary>
        public string CollateralType { get; set; }

        public string 抵押物币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 抵押物金额
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// 登记机关
        /// </summary>
        public string RegistrateAuthorit { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public string RegistrateDate { get; set; }

        /// <summary>
        /// 抵押物说明
        /// </summary>
        public string CollateralInstruction { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        public string EffectiveState { get; set; }
    }
}
