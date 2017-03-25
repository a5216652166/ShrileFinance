namespace Core.Entities.Loan
{
    using System;
    using Exceptions;
    using Interfaces;

    /// <summary>
    /// 还款记录
    /// </summary>
    public class PaymentHistory : Entity, IAggregateRoot, IProcessable
    {
        public PaymentHistory(
            decimal scheduledPaymentPrincipal,
            decimal scheduledPaymentInterest,
            decimal actualPaymentPrincipal,
            decimal actualPaymentInterest)
        {
            if (scheduledPaymentPrincipal < actualPaymentPrincipal)
            {
                throw new ArgumentOutOfRangeAppException(message: "应还本金必须大于等于实际偿还本金.");
            }

            if (scheduledPaymentInterest < actualPaymentInterest)
            {
                throw new ArgumentOutOfRangeAppException(message: "应还利息必须大于等于实际偿还利息.");
            }

            ScheduledPaymentPrincipal = scheduledPaymentPrincipal;
            ScheduledPaymentInterest = scheduledPaymentInterest;
            ActualPaymentPrincipal = actualPaymentPrincipal;
            ActualPaymentInterest = actualPaymentInterest;
            ////ActualDatePayment = DateTime.Now;
        }

        protected PaymentHistory()
        {
        }

        ////public HiddenEnum Hidden { get; set; } = HiddenEnum.审核中;

        /// <summary>
        /// 借据标识
        /// </summary>
        public Guid LoanId { get; set; }

        /// <summary>
        /// 应还本金
        /// </summary>
        public decimal ScheduledPaymentPrincipal { get; private set; }

        /// <summary>
        /// 应还利息
        /// </summary>
        public decimal ScheduledPaymentInterest { get; private set; }

        /// <summary>
        /// 实际偿还本金
        /// </summary>
        public decimal ActualPaymentPrincipal { get; private set; }

        /// <summary>
        /// 实际偿还利息
        /// </summary>
        public decimal ActualPaymentInterest { get; private set; }

        /// <summary>
        /// 实际还款日期
        /// </summary>
        public DateTime ActualDatePayment { get; set; }

        /// <summary>
        /// 应还款日期
        /// </summary>
        public DateTime ScheduledDatePayment { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        public string PaymentTypes { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; protected set; }

        public void AllotCreateDate()
            => CreateDate = DateTime.Now;

        /////// <summary>
        /////// 该还款信息所属流程ID
        /////// </summary>
        ////public Guid InstanceId { get; set; }
    }
}
