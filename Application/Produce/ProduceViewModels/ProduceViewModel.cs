namespace Application.Produce.ProduceViewModels
{
    using System;
    using System.Collections.Generic;

    public class ProduceViewModel
    {
        public Guid Id { get; private set; }

        public string Code { get; set; }

        public string ProduceType { get; set; }

        public decimal Rate { get; set; }

        public int Periods { get; set; }

        public int PeriodsPerpayment { get; set; }

        public decimal CustomerCostRatio { get; set; }

        public decimal CustomerBailRatio { get; set; }

        public decimal CostRate { get; set; }

        public decimal CostRateYear => Math.Round(CostRate * 12, 2);

        public decimal PartnersCommissionRatio { get; set; }

        public decimal EmployeeCommissionRatio { get; set; }

        public IEnumerable<PrincipalRatioViewModel> PrincipalRatios { get; set; }
    }
}
