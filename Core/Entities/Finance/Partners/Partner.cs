namespace Core.Entities.Finance.Partners
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Produce;

    public class Partner : Entity, IAggregateRoot
    {
        public Partner()
        {
            Produces = new HashSet<Produce>();
            Approvers = new HashSet<AppUser>();
            Accounts = new HashSet<AppUser>();
            DateCreated = DateTime.Now;
        }

        public string Name { get; set; }

        public decimal LineOfCredit { get; set; }

        public decimal AmountOfBail { get; set; }

        public string Address { get; set; }

        public string ProxyArea { get; set; }

        public string VehicleManage { get; set; }

        public string ControllerName { get; set; }

        public string ControllerIdentity { get; set; }

        public string ControllerPhone { get; set; }

        public DateTime DateCreated { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<Produce> Produces { get; set; }

        public virtual ICollection<AppUser> Approvers { get; set; }

        public virtual ICollection<AppUser> Accounts { get; set; }
    }
}
