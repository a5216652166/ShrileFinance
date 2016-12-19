namespace Core.Entities.Message.BorrowMessage.Organization
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Base
    {
        /// <summary>
        /// 类别
        /// </summary>
        public string 信息类别
        {
            get
            {
                return "B";
            }
        }

        /// <summary>
        /// 客户号
        /// </summary>
        [Display(Name = "客户号"), StringLength(40), Required]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 管理行代码
        /// </summary>
        [Display(Name = "管理行代码"), StringLength(20), Required]
        public string ManagementerCode { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        [Display(Name = "客户类型"), StringLength(1), Required]
        public string CustomerType { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18)]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10)]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [Display(Name = "登记注册号类型"), StringLength(2)]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        [Display(Name = "登记注册号码"), StringLength(20)]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 纳税人识别号（国税）
        /// </summary>
        [Display(Name = "纳税人识别号（国税）"), StringLength(20)]
        public string TaxpayerIdentifyIrsNumber { get; set; }

        /// <summary>
        /// 纳税人识别号（地税）
        /// </summary>
        [Display(Name = "纳税人识别号（地税）"), StringLength(20)]
        public string TaxpayerIdentifyLandNumber { get; set; }

        public string 开户许可证核准号
        {
            get { return string.Empty.PadLeft(30, ' '); }
        }

        /// <summary>
        /// 中征码
        /// </summary>
        [Display(Name = "中征码"), StringLength(16), Required]
        public string LoanCardCode { get; set; }

        public string 数据提取日期
        {
            get { return DateTime.Now.ToString("yyyyMMdd"); }
        }

        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
