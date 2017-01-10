namespace Core.Services.Loan
{
    using System;
    using Entities.Loan;
    using Exceptions;

    /// <summary>
    /// 放款服务
    /// </summary>
    public class LoanService
    {
        /// <summary>
        /// 放款
        /// </summary>
        /// <param name="loan">借据</param>
        /// <param name="credit">授信合同</param>
        public void Loan(Loan loan, CreditContract credit)
        {
            if (!credit.CanApplyLoan(loan.Principle, loan.SpecialDate))
            {
                throw new InvalidOperationAppException("申请贷款失败, 请确认授信合同是否有效、授信余额是否充足借据放款时间是否在合同有效期内.");
            }

            credit.Loans.Add(loan);
        }
    }
}
