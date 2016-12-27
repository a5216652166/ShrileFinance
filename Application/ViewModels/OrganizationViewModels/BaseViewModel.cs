namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 基础段
    /// </summary>
    [BasePeriod_OR(ErrorMessage = "基础信息 组织机构代码和登记注册号码不能同时为空")]
    [BasePeriod_TN(ErrorMessage = "基础信息 登记注册号类型和登记注册号码需成对出现")]
    public class BaseViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 客户号
        /// </summary>
        [Display(Name = "客户号"), StringLength(40), Required, AN(ErrorMessage = "客户号 类型错误")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 管理行代码
        /// </summary>
        [Display(Name = "管理行代码"), StringLength(20), Required, AN(ErrorMessage = "管理行代码 类型错误")]
        public string ManagementerCode { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        [Display(Name = "客户类型"), StringLength(1), Required, AN(ErrorMessage = "客户类型 类型错误"), CustomerType(ErrorMessage = "客户类型 值错误")]
        public string CustomerType { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), AN(ErrorMessage = "机构信用代码 类型错误")]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), AN(ErrorMessage = "组织机构代码 类型错误"), OrganizateCode(ErrorMessage = "组织机构代码 验证未通过")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [Display(Name = "登记注册号类型"), StringLength(2), AN(ErrorMessage = "登记注册号类型 类型错误"), RegistrationNumberType(ErrorMessage = "登记注册号类型 值错误")]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        [Display(Name = "登记注册号码"), StringLength(20), ANC(ErrorMessage = "登记注册号码 类型错误")]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 纳税人识别号（国税）
        /// </summary>
        [Display(Name = "纳税人识别号（国税）"), StringLength(20), TaxpayerIdentify, ANC(ErrorMessage = "纳税人识别号（国税） 类型错误")]
        public string TaxpayerIdentifyIrsNumber { get; set; }

        /// <summary>
        /// 纳税人识别号（地税）
        /// </summary>
        [Display(Name = "纳税人识别号（地税）"), StringLength(20), TaxpayerIdentify, ANC(ErrorMessage = "纳税人识别号（地税） 类型错误")]
        public string TaxpayerIdentifyLandNumber { get; set; }

        /// <summary>
        /// 中征码
        /// </summary>
        [Display(Name = "中征码"), StringLength(16), Required, AN(ErrorMessage = "中征码 类型错误"), CreditCard(ErrorMessage = "中征码（贷款卡编码） 校验未通过")]
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 是否有上级机构
        /// </summary>
        [Display(Name = "是否有上级机构")]
        public bool HasParent { get; set; }
    }
}
