namespace Application.ViewModels.FinanceViewModels.BranchOfficeViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 分公司ViewModel
    /// </summary>
    public class BranchOfficeViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "子公司名称必填")]
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Required(ErrorMessage = "子公司电话必填")]
        public string Phone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "子公司地址必填")]
        public string Address { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        [Required(ErrorMessage = "子公司开户行必填")]
        public string BankName { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "子公司账号必填")]
        public string BankAcount { get; set; }
    }
}
