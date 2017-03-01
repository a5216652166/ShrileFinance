namespace Core.Entities.Loan
{
    using System;

    public enum EffectiveStateEnum : byte
    {
        是 = 1,
        否 = 2
    }

    public enum GuaranteeFormEnum : byte
    {
        单人担保 = 1,
        多人联保 = 2,
        多人分保 = 3
    }

    /// <summary>
    /// 担保合同
    /// </summary>
    public class GuarantyContract : Entity
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime? SigningDate { get; set; }

        /// <summary>
        /// 担保形式
        /// </summary>
        public GuaranteeFormEnum? GuaranteeForm { get; set; }

        /// <summary>
        /// 有效状态
        /// </summary>
        public EffectiveStateEnum? EffectiveState { get; set; }

        /// <summary>
        /// 保证金额
        /// </summary>
        public decimal? Margin { get; set; }

        /// <summary>
        /// 担保人
        /// </summary>
        public virtual Guarantor Guarantor { get; set; }
    }
}
