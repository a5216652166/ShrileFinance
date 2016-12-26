namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 基础段（家族）
    /// </summary>
    [FBasePeriod_FOR(ErrorMessage = "家族成员证件号码和证件类型成对出现")]
    public class FamilyMemberViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 家族成员关系
        /// </summary>
        [Display(Name = "家族成员关系"), StringLength(1), AN(ErrorMessage = "家族成员关系 类型错误"), FamilyRelationship(ErrorMessage = "家族关系 值错误")]
        public string Relationship { get; set; }

        /// <summary>
        /// 家族成员姓名
        /// </summary>
        [Display(Name = "家族成员姓名"), StringLength(80), Required, ANC(ErrorMessage = "家族成员姓名类型错误")]
        public string Name { get; set; }

        /// <summary>
        /// 家族成员证件类型
        /// </summary>
        [Display(Name = "家族成员证件类型"), StringLength(2), Required, ANC(ErrorMessage = "家族成员证件类型 类型错误"), CertificateType(ErrorMessage = "家族成员证件类型 值错误")]
        public string CertificateType { get; set; }

        /// <summary>
        /// 家族成员证件号码
        /// </summary>
        [Display(Name = "家族成员证件号码"), StringLength(20), Required, ANC(ErrorMessage = "家族成员证件号码 类型错误")]
        public string CertificateCode { get; set; }
    }
}
