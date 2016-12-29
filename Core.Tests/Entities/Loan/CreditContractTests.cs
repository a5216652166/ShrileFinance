namespace Core.Tests.Entities.Loan
{
    using System;
    using Core.Entities.Loan;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CreditContractTests
    {
        /// <summary>
        /// 校验是否能申请贷款
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeAppException))]
        public void CanApplyLoan()
        {
            var creditContract = new CreditContract(DateTime.MinValue, DateTime.MaxValue, 10000, CreditContractStatusEnum.失效);
            var result = creditContract.CanApplyLoan(100000, DateTime.Now);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// 校验生效日期
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeAppException))]
        public void ValidEffectiveDate()
        {
            var creditContract = new CreditContract(DateTime.MaxValue, DateTime.MinValue, 10000, CreditContractStatusEnum.失效);

            Assert.Fail();
        }

        /// <summary>
        /// 校验终止日期
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeAppException))]
        public void ValidExpirationDate()
        {
            var creditContract = new CreditContract(DateTime.MaxValue, DateTime.MinValue, 10000, CreditContractStatusEnum.失效);

            Assert.Fail();
        }

        /// <summary>
        /// 额度变更
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeAppException))]
        public void ChangeLimit()
        {
            var creditContract = new CreditContract(DateTime.MaxValue, DateTime.MinValue, 10000, CreditContractStatusEnum.失效);
            creditContract.ChangeLimit(5000);
            Assert.Fail();
        }
    }
}
