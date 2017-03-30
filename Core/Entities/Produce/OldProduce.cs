namespace Core.Entities.Produce
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    ////public class OldProduce : Entity, IAggregateRoot
    ////{
    ////    public OldProduce()
    ////    {
    ////        CreatedDate = DateTime.Now;
    ////    }

    ////    /// <summary>
    ////    /// 还款方式枚举
    ////    /// </summary>
    ////    public enum RepaymentMethodEnum : byte
    ////    {
    ////        /// <summary>
    ////        /// 等额本息
    ////        /// </summary>
    ////        等额本息 = 1,

    ////        /// <summary>
    ////        /// 月供提前付
    ////        /// </summary>
    ////        月供提前付 = 2,

    ////        /// <summary>
    ////        /// 一次性付息
    ////        /// </summary>
    ////        一次性付息 = 3
    ////    }

    ////    /// <summary>
    ////    /// 产品代码
    ////    /// </summary>
    ////    public string Code { get; set; }

    ////    /// <summary>
    ////    /// 产品名称
    ////    /// </summary>
    ////    public string Name { get; set; }

    ////    /// <summary>
    ////    /// 月利率
    ////    /// </summary>
    ////    public decimal InterestRate { get; set; }

    ////    /// <summary>
    ////    /// 费率
    ////    /// </summary>
    ////    public decimal CostRate { get; set; }

    ////    /// <summary>
    ////    /// 还款方式
    ////    /// </summary>
    ////    public RepaymentMethodEnum RepaymentMethod { get; set; }

    ////    /// <summary>
    ////    /// 最小融资比例
    ////    /// </summary>
    ////    public decimal MinFinancingRatio { get; set; }

    ////    /// <summary>
    ////    /// 最大融资比例
    ////    /// </summary>
    ////    public decimal MaxFinancingRatio { get; set; }

    ////    /// <summary>
    ////    /// 尾款比例
    ////    /// </summary>
    ////    public decimal FinalRatio { get; set; }

    ////    /// <summary>
    ////    /// 融资期限
    ////    /// </summary>
    ////    public int FinancingPeriods { get; set; }

    ////    /// <summary>
    ////    /// 还款间隔
    ////    /// </summary>
    ////    public int RepaymentInterval { get; set; }

    ////    /// <summary>
    ////    /// 客户保证金比例
    ////    /// </summary>
    ////    public decimal CustomerBailRatio { get; set; }

    ////    /// <summary>
    ////    /// 数据添加时间
    ////    /// </summary>
    ////    public DateTime CreatedDate { get; set; }

    ////    /// <summary>
    ////    /// 备注
    ////    /// </summary>
    ////    public string Remarks { get; set; }

    ////    /// <summary>
    ////    /// 每个产品对应的融资项
    ////    /// </summary>
    ////    public virtual ICollection<FinancingItem> FinancingItems { get; set; }
    ////}
}
