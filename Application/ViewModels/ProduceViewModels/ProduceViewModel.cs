//namespace Application.ViewModels.ProduceViewModel
//{
//    using System;
//    using System.Collections.Generic;

//    ////public class ProduceViewModel
//    ////{
//    ////    public ProduceViewModel()
//    ////    {
//    ////        FinancingItemsList = new HashSet<FinancingProjectListViewModel>();

//    ////        PoundageList = new HashSet<FinancingProjectListViewModel>();
//    ////    }

//    ////    /// <summary>
//    ////    /// 还款方式枚举
//    ////    /// </summary>
//    ////    public enum RepaymentMethodEnum : byte
//    ////    {
//    ////        /// <summary>
//    ////        /// 等额本息
//    ////        /// </summary>
//    ////        等额本息 = 1,

//    ////        /// <summary>
//    ////        /// 月供提前付
//    ////        /// </summary>
//    ////        月供提前付 = 2,

//    ////        /// <summary>
//    ////        /// 一次性付息
//    ////        /// </summary>
//    ////        一次性付息 = 3
//    ////    }

//    ////    public Guid Id { get; set; }

//    ////    /// <summary>
//    ////    /// 产品代码
//    ////    /// </summary>
//    ////    public string Code { get; set; }

//    ////    /// <summary>
//    ////    /// 产品名称
//    ////    /// </summary>
//    ////    public string Name { get; set; }

//    ////    /// <summary>
//    ////    /// 名义利率
//    ////    /// </summary>
//    ////    public decimal InterestRate { get; set; }

//    ////    /// <summary>
//    ////    /// 费率
//    ////    /// </summary>
//    ////    public decimal CostRate { get; set; }

//    ////    /// <summary>
//    ////    /// 还款方式
//    ////    /// </summary>
//    ////    public RepaymentMethodEnum RepaymentMethod { get; set; }

//    ////    public string RepaymentMethodDesc { get
//    ////        { return RepaymentMethod.ToString(); }
//    ////    }

//    ////    /// <summary>
//    ////    /// 最小融资比例
//    ////    /// </summary>
//    ////    public decimal MinFinancingRatio { get; set; }

//    ////    /// <summary>
//    ////    /// 最大融资比例
//    ////    /// </summary>
//    ////    public decimal MaxFinancingRatio { get; set; }

//    ////    /// <summary>
//    ////    /// 尾款比例
//    ////    /// </summary>
//    ////    public decimal FinalRatio { get; set; }

//    ////    /// <summary>
//    ////    /// 融资期限
//    ////    /// </summary>
//    ////    public int FinancingPeriods { get; set; }

//    ////    /// <summary>
//    ////    /// 还款间隔
//    ////    /// </summary>
//    ////    public int RepaymentInterval { get; set; }

//    ////    /// <summary>
//    ////    /// 客户保证金比例
//    ////    /// </summary>
//    ////    public decimal CustomerBailRatio { get; set; }

//    ////    /// <summary>
//    ////    /// 备注
//    ////    /// </summary>
//    ////    public string Remarks { get; set; }

//    ////    /// <summary>
//    ////    /// 每个产品对应的融资项
//    ////    /// </summary>
//    ////    public virtual ICollection<FinancingItemViewModel> FinancingItems { get; set; }

//    ////    /// <summary>
//    ////    /// 每个产品对应的手续费
//    ////    /// </summary>
//    ////    public virtual ICollection<FinancingItemViewModel> Poundage { get; set; }

//    ////    public virtual ICollection<FinancingProjectListViewModel> FinancingItemsList { get; set; }

//    ////    public virtual ICollection<FinancingProjectListViewModel> PoundageList { get; set; }
//    ////}
//}
