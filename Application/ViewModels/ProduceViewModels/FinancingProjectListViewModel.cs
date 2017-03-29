namespace Application.ViewModels.ProduceViewModels
{
    using System;

    public class FinancingProjectListViewModel
    {
        /// <summary>
        /// 融资项目标识
        /// </summary>
        public Guid FinancingProjectId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否为可融项目
        /// </summary>
        public bool IsFinancing { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool IsEdit { get; set; }
    }
}
