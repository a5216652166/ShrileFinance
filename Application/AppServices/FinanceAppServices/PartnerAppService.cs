namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Finance.Partners;
    using Core.Entities.Identity;
    using Core.Interfaces.Repositories.FinanceRepositories.FinancialRepositories;
    using Core.Interfaces.Repositories.ProcessRepositories;
    using Microsoft.AspNet.Identity;
    using Produce.ProduceViewModels;
    using ViewModels.AccountViewModels;
    using ViewModels.PartnerViewModels;
    using Core.Produce;
    using X.PagedList;

    public class PartnerAppService
    {
        private readonly IPartnerRepository repository;
        private readonly IProduceRepository produceRepository;
        private readonly AppUserManager userManager;
        private readonly AccountAppService accountService;
        private readonly AppRoleManager roleManager;

        public PartnerAppService(
            IPartnerRepository repository,
            IProduceRepository produceRepository,
            AppUserManager userManager,
            AppRoleManager roleManager,
            AccountAppService accountService)
        {
            this.repository = repository;
            this.produceRepository = produceRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.accountService = accountService;
        }

        public PartnerViewModel Get(Guid key)
        {
            var partner = repository.Get(key);

            var model = Mapper.Map<PartnerViewModel>(partner);

            model.Approvers = partner.Approvers.Select(m => m.Id);

            foreach (var item in model.Accounts)
            {
                var role = roleManager.FindById(partner.Accounts.Single(m => m.Id == item.Id).RoleId);

                item.Role = role.Name;
            }

            return model;
        }

        public async Task Create(PartnerViewModel model)
        {
            var partner = Mapper.Map<Partner>(model);

            var produceIds = model.Produces.Select(m => m.Id);
            partner.Produces = produceRepository.GetAll(m => produceIds.Contains(m.Id)).ToList();

            partner.Approvers = userManager.Users.Where(m => model.Approvers.Contains(m.Id)).ToList();

            if (partner.Approvers.Select(m => m.RoleId).Count() != 5)
            {
                throw new Core.Exceptions.InvalidOperationAppException("每个角色有且仅有一个审批用户.");
            }

            if (model.Accounts.Count() > 0)
            {
                foreach (var item in model.Accounts)
                {
                    var idenResult = await accountService.CreateUserAsync(item);

                    if (!idenResult.Succeeded)
                    {
                        throw new Core.Exceptions.ArgumentAppException(idenResult.Errors.First());
                    }

                    var entity = userManager.FindById(item.Id);
                    partner.Accounts.Add(entity);

                    Mapper.Map(entity, item);
                }
            }

            repository.Create(partner);
            repository.Commit();
        }

        public async Task ModifyAsync(PartnerViewModel model)
        {
            var partner = repository.Get(model.Id.Value);

            Mapper.Map(model, partner);

            var produceIds = model.Produces.Select(m => m.Id);
            partner.Produces.Clear();
            partner.Produces = produceRepository.GetAll(m => produceIds.Contains(m.Id)).ToList();

            partner.Approvers.Clear();
            partner.Approvers = userManager.Users.Where(m => model.Approvers.Contains(m.Id)).ToList();

            if (partner.Approvers.Select(m => m.RoleId).Count() != 5)
            {
                throw new Core.Exceptions.InvalidOperationAppException("每个角色有且仅有一个审批用户.");
            }

            if (model.Accounts == null)
            {
                model.Accounts = new UserViewModel[] { };
            }

            var modelIds = model.Accounts.Select(m => m.Id);
            partner.Accounts.Where(m => !modelIds.Contains(m.Id)).ToList()
                .ForEach(m => partner.Accounts.Remove(m));

            foreach (var item in model.Accounts)
            {
                var entity = partner.Accounts.SingleOrDefault(m => m.Id == item.Id);

                if (entity == null)
                {
                    var idenResult = await accountService.CreateUserAsync(item);

                    if (!idenResult.Succeeded)
                    {
                        throw new Core.Exceptions.ArgumentAppException(idenResult.Errors.First());
                    }

                    entity = userManager.FindById(item.Id);
                    partner.Accounts.Add(entity);
                }

                Mapper.Map(entity, item);
            }

            repository.Modify(partner);
            repository.Commit();
        }

        public async Task CreateAccount(UserViewModel model, Guid partnerId)
        {
            var partner = repository.Get(partnerId);

            if (model.Role != "C342BEE1-05A4-E611-80C5-507B9DE4A488" && model.Role != "C442BEE1-05A4-E611-80C5-507B9DE4A488")
            {
                throw new Core.Exceptions.InvalidOperationAppException("用户的角色只能是客户经理或渠道经理.");
            }

            var createResult = await accountService.CreateUserAsync(model);

            if (!createResult.Succeeded)
            {
                throw new InvalidOperationException("创建用户失败.");
            }

            var user = userManager.FindById(model.Id);

            partner.Accounts.Add(user);

            repository.Commit();
        }

        public IPagedList<PartnerViewModel> List(string searchString, int page, int size)
        {
            var partners = repository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                partners.Where(m => m.Name.Contains(searchString)
                    || m.ControllerName.Contains(searchString));
            }

            var list = partners.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<PartnerViewModel>>(list);

            return models;
        }

        public IEnumerable<ProduceViewModel> GetListByPartner(string serach)
        {
            var partner = repository.GetByUser(userManager.CurrentUser());
            var produces = partner.Produces.AsEnumerable();

            if (!string.IsNullOrEmpty(serach))
            {
                produces = produces.Where(m => m.Code.Contains(serach));
            }

            return Mapper.Map<IEnumerable<ProduceViewModel>>(produces);
        }
    }
}
