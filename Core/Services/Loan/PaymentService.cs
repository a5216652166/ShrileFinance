namespace Core.Services.Loan
{
    using System.Collections.Generic;
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
        /// <param name="traceTypes">跟踪类型集合</param>
        public void Payment(Loan loan, PaymentHistory payment)
        {
            // 新增还款记录
           // loan.AddPaymentHistory(payment);

            ////traceTypes = new List<TraceTypeEnum>();

            if (payment.ActualPaymentPrincipal > 0)
            {
                // 还款
                // 调整四级分类
                loan.SetFourCategoryAssetsClassification(FourCategoryAssetsClassificationEnum.正常);

                //// 报文追踪（还款信息记录）
                //traceTypes.Add(TraceTypeEnum.还款);
            }

            if (payment.ScheduledPaymentPrincipal > payment.ActualPaymentPrincipal)
            {
                // 逾期
                // 调整四级分类
                loan.SetFourCategoryAssetsClassification(FourCategoryAssetsClassificationEnum.逾期);

                //// 报文追踪（五级分类调整 借据信息记录）
                //traceTypes.Add(TraceTypeEnum.逾期);
            }

            if (payment.ScheduledPaymentInterest > payment.ActualPaymentInterest)
            {
                //// 欠息
                //traceTypes.Add(TraceTypeEnum.欠息);
            }
        }
    }
}
