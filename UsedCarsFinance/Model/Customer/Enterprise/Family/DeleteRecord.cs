﻿using System.ComponentModel.DataAnnotations;

namespace Model.Customer.Enterprise.Family
{
    /// <summary>
    /// 删除报文记录
    /// </summary>
    public class DeleteRecord
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        [Display(Name = "信息类别"), StringLength(1), Required, AN(ErrorMessage = "信息类别类型错误")]
        public string InformationCategories
        {
            get
            {
                return "B";
            }
        }

        /// <summary>
        /// 主要关系人证件类型
        /// </summary>
        [Display(Name = "主要关系人证件类型"), StringLength(2), Required, AN(ErrorMessage = "主要关系人证件类型类型错误")]
        public string MainParticipantCertificateType { get; set; }

        /// <summary>
        /// 主要关系人证件号码
        /// </summary>
        [Display(Name = "主要关系人证件号码"), StringLength(20), Required, ANC(ErrorMessage = "主要关系人证件号码类型错误")]
        public string MainParticipantCertificateNumber { get; set; }

        /// <summary>
        /// 家族关系
        /// </summary>
        [Display(Name = "家族关系"), StringLength(1), AN(ErrorMessage = "家族关系类型错误")]
        public string FamilyRelationship { get; set; }

        /// <summary>
        /// 家族成员证件类型
        /// </summary>
        [Display(Name = "家族成员证件类型"), StringLength(2), Required, ANC(ErrorMessage = "家族成员证件类型类型错误")]
        public string FamilyMembersCertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [Display(Name = "家族成员证件号码"), StringLength(20), Required, ANC(ErrorMessage = "家族成员证件号码类型错误")]
        public string FamilyMembersCertificateNumber { get; set; }

        /// <summary>
        /// 数据提取日期
        /// </summary>
        [Display(Name = "信息更新日期"), StringLength(8), Required, N(ErrorMessage = "信息更新日期类型错误")]
        public string DataUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [Display(Name = "预留字段"), StringLength(40), ANC(ErrorMessage = "预留字段类型错误")]
        public string ReservedField { get; set; }
    }
}
