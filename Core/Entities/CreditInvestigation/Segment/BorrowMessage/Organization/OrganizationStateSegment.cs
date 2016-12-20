namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Organization
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrganizationStateSegment : AbsSegment
    {
        public string 信息类别
        {
            get { return "D"; }
        }

        public string 基本户状态
        {
            get { return " "; }
        }

        /// <summary>
        /// 企业规模
        /// </summary>
        [Display(Name = "企业规模"), StringLength(1), MinLength(1)]
        public string EnterpriseScale { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        [Display(Name = "机构状态"), StringLength(1), MinLength(1)]
        public string InstitutionsState { get; set; }

        public string 信息更新日期 { get; set; }

        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
