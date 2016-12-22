namespace Core.Services.Loan
{
    using System;
    using Entities.CreditInvestigation;
    using Entities.Loan;

    /// <summary>
    /// 还款服务
    /// </summary>
    public class PaymentService
    {
        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="loan">借据</param>
        /// <param name="payment">还款记录</param>
        public void Payment(Loan loan, PaymentHistory payment, Action<Guid, TraceTypeEnum, string> trace)
        {
            if (payment.ScheduledPaymentPrincipal == payment.ActualPaymentPrincipal
                && payment.ScheduledPaymentInterest == payment.ActualPaymentInterest)
            {
                // 还款
                // 新增还款记录
                loan.AddPaymentHistory(payment);

                // 调整四级分类
                loan.SetFourCategoryAssetsClassification(FourCategoryAssetsClassificationEnum.正常);

                // 报文追踪（还款信息记录）
                trace(payment.Id, TraceTypeEnum.还款,"借据：" + loan.ContractNumber + "还款，还款编号：" + payment.Id);

                // 报文追踪（五级分类调整 借据信息记录）
                trace(payment.LoanId,TraceTypeEnum.还款, "借据：" + loan.ContractNumber + "五级分类调整");
            }
            else if (payment.ScheduledPaymentPrincipal > payment.ActualPaymentPrincipal)
            {
                // 逾期
                // 新增还款记录
                loan.AddPaymentHistory(payment);

                // 调整四级分类
                loan.SetFourCategoryAssetsClassification(FourCategoryAssetsClassificationEnum.逾期);

                // 报文追踪（五级分类调整 借据信息记录）
                trace(payment.LoanId, TraceTypeEnum.逾期, "借据：" + loan.ContractNumber + "逾期，五级分类调整");
            }
            else
            {
                // 欠息
                // 新增还款记录
                loan.AddPaymentHistory(payment);

                // 报文追踪（五级分类调整 借据信息记录）
                trace(payment.Id, TraceTypeEnum.欠息, "借据：" + loan.ContractNumber + "欠息，五级分类调整");
            }
        }
    }
}
