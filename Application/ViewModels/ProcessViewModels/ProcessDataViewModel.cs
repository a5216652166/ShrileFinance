namespace Application.ViewModels.ProcessViewModels
{
    using System;
    using System.Collections.Generic;
    using Loan.CreditViewModel;
    using Loan.LoanViewModels;
    using OrganizationViewModels;

    public class ProcessDataViewModel
    {
        public Guid? InstanceId { get; set; }

        public OrganizationViewModel Organization { get; set; }

        public OrganizationChangeViewModel OrganizationChange { get; set; }

        public CreditContractViewModel CreditContract { get; set; }

        public LoanViewModel Loan { get; set; }

        public PaymentViewModel Payments { get; set; }
    }
}
