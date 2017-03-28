namespace Application.AppServices.FinanceAppServices.PartnerAppServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Core.Interfaces.Repositories.FinanceRepositories.PartnerRepositories;

    public class PartnerUserAppService
    {
        private readonly IPartnerRepository partnerRepository;

        public PartnerUserAppService(IPartnerRepository partnerRepository)
        {
            this.partnerRepository = partnerRepository;
        }
    }
}
