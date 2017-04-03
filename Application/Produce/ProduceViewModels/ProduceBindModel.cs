namespace Application.Produce.ProduceViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProduceBindModel
    {
        public Guid? Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string ProduceType { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public int Periods { get; set; }

        public int PeriodsPerpayment { get; set; }

        public decimal CustomerCostRatio { get; set; }

        public decimal CustomerBailRatio { get; set; }

        public decimal CostRate { get; set; }

        public decimal PartnersCommissionRatio { get; set; }

        public decimal EmployeeCommissionRatio { get; set; }

        public IEnumerable<PrincipalRatioViewModel> PrincipalRatios { get; set; }
    }
}
