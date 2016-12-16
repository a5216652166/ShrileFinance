namespace Core.Entities.Message.BorrowMessage.Organization
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrganizationContact
    {
        public string 信息类别
        {
            get { return "E"; }
        }

        /// <summary>
        /// 办公（生产、经营）地址
        /// </summary>
        [Display(Name = "办公（生产、经营）地址"), StringLength(80)]
        public string OfficeAddress { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话"), StringLength(35)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 财务部联系电话
        /// </summary>
        [Display(Name = "财务部联系电话"), StringLength(35)]
        public string FinancialContactPhone { get; set; }

        [StringLength(8)]
        public string 信息更新日期 { get; set; }

        public string 预留字段
        {
            get { return string.Empty.PadLeft(40, ' '); }
        }
    }
}
