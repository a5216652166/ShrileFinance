namespace Application.ViewModels.PartnerViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AccountViewModels;

    public class PartnerViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal LineOfCredit { get; set; }

        [Required]
        public decimal AmountOfBail { get; set; }

        public string Address { get; set; }

        public string ProxyArea { get; set; }

        public string VehicleManage { get; set; }

        public string ControllerName { get; set; }

        public string ControllerIdentity { get; set; }

        public string ControllerPhone { get; set; }

        public string Remarks { get; set; }

        public IEnumerable<ProduceOptionViewModel> Produces { get; set; } = new HashSet<ProduceOptionViewModel>();

        public IEnumerable<string> Approvers { get; set; } = new HashSet<string>();

        public IEnumerable<UserViewModel> Accounts { get; set; } = new HashSet<UserViewModel>();
    }
}
