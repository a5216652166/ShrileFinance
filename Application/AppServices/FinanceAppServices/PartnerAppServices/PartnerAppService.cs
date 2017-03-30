namespace Application.AppServices.FinanceAppServices.PartnerAppServices
{
    using System;
    using System.Collections.Generic;
    using Application.ViewModels.FinanceViewModels.PartnerViewModels;
    using Core.Entities;
    using Core.Entities.Finance.Partners;
    using Core.Interfaces.Repositories.FinanceRepositories.PartnerRepositories;
    using static AutoMapper.Mapper;

    public class PartnerAppService
    {
        private readonly INewPartnerRepository partnerRepository;
        private readonly AppUserManager userManager;

        public PartnerAppService(INewPartnerRepository partnerRepository, AppUserManager userManager)
        {
            this.partnerRepository = partnerRepository;
            this.userManager = userManager;
        }

        public NewPartnerViewModel Get(Guid partnerId)
        {
            var partner = partnerRepository.Get(partnerId);

            return Map<NewPartnerViewModel>(partner);
        }

        public IEnumerable<NewPartnerViewModel> PartnerList(string name, int page, int size)
        {
            var partnerList = partnerRepository.PartnerList(name, page, size);

            return Map<IEnumerable<NewPartnerViewModel>>(partnerList);
        }

        public void Create(NewPartnerViewModel model)
        {
            var partner = Map<NewPartner>(model);

            partnerRepository.Create(partner);
            partnerRepository.Commit();
        }

        public void Modify(NewPartnerViewModel model)
        {
            var partner = partnerRepository.Get(model.Id);

            Map(model, partner);

            UpdateBind.BindCollection(partner.Produces, model.Produces);
            UpdateBind.BindCollection(partner.PartnerUsers, model.PartnerUsers);

            partnerRepository.Modify(partner);
            partnerRepository.Commit();
        }

        public void Remove(Guid partnerId)
        {
            var partner = partnerRepository.Get(partnerId);

            // 禁用该合作商下的所有账户
            foreach (var item in partner.PartnerUsers)
            {
                userManager.SetLockoutEnabledAsync(item.AppUser.Id, true).Start();
            }

            partnerRepository.Remove(partner);
            partnerRepository.Commit();
        }
    }
}
