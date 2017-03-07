namespace Core.Entities.Loan
{
    using System;

    public enum CollateralTypeEnum : byte
    {
        房产 = 1,
        土地使用权 = 2,
        在建工程 = 3,
        交通工具 = 4,
        机器设备 = 5,
        其他类 = 6,
    }

    /// <summary>
    /// 抵押保证合同
    /// </summary>
    public class GuarantyContractMortgage : GuarantyContract
    {
        /// <summary>
        /// 抵押序号
        /// </summary>
        public string MortgageNumber { get; set; } 

        /// <summary>
        /// 抵押物评估价值
        /// </summary>
        public decimal? AssessmentValue { get; set; }

        /// <summary>
        /// 抵押物评估日期
        /// </summary>
        public DateTime? AssessmentDate { get; set; }

        /// <summary>
        /// 评估机构名称
        /// </summary>
        public string AssessmentName { get; set; }

        /// <summary>
        /// 评估机构组织机构代码
        /// </summary>
        public string AssessmentOrganizationCode { get; set; }

        /// <summary>
        /// 抵押物种类
        /// </summary>
        public CollateralTypeEnum? CollateralType { get; set; }

        /// <summary>
        /// 登记机关
        /// </summary>
        public string RegistrateAuthorit { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime? RegistrateDate { get; set; }

        /// <summary>
        /// 抵押物说明
        /// </summary>
        public string CollateralInstruction { get; set; }
    }
}
