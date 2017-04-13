namespace Core.Produce.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Produce;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PaymentEqualsCalculatorServiceTests
    {
        private readonly PaymentEqualsCalculatorService service;

        public PaymentEqualsCalculatorServiceTests()
        {
            service = new PaymentEqualsCalculatorService();
        }

        [TestMethod]
        public void YearlyPaymentTest()
        {
            var principal = 10000m;
            var rate = 0.01275m;
            var ratios = new List<PrincipalRatio>
            {
                new PrincipalRatio { Period = 1, Ratio = 0.24m },
                new PrincipalRatio { Period = 2, Ratio = 0.24m },
                new PrincipalRatio { Period = 3, Ratio = 0.20m },
                new PrincipalRatio { Period = 4, Ratio = 0.18m },
                new PrincipalRatio { Period = 5, Ratio = 0.14m }
            };

            var expectedPayments =
                service.YearlyPayment(ratios, principal, rate);

            Assert.AreEqual(expectedPayments.Count(), 5);

            var actualPayments = new List<PrincipalRatio>
            {
                new PrincipalRatio { Period = 1, Factor = 299.7207m },
                new PrincipalRatio { Period = 2, Factor = 299.7207m },
                new PrincipalRatio { Period = 3, Factor = 221.5999m },
                new PrincipalRatio { Period = 4, Factor = 180.5699m },
                new PrincipalRatio { Period = 5, Factor = 126.5599m }
            };

            for (int i = 0; i < actualPayments.Count; i++)
            {
                var expected =
                    Math.Round(expectedPayments.ElementAt(i).Factor, 4);
                var actual = actualPayments.ElementAt(i).Factor;

                Assert.AreEqual(expected, actual);
            }
        }
    }
}