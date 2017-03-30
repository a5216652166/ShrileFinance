namespace Application.ViewModels.ProduceViewModels
{
    public class PoundageViewModel
    {
        /// <summary>
        /// 融资项目标识
        /// </summary>
        public System.Guid FinancingProjectId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// 融资项目
        /// </summary>
        public virtual FinancingProjectViewModel FinancingProject { get; set; }
    }
}
