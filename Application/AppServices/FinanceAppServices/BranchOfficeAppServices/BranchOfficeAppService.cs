namespace Application.AppServices.FinanceAppServices.BranchOfficeAppServices
{
    using System;
    using Application.ViewModels.FinanceViewModels.BranchOfficeViewModels;
    using Core.Entities.Finance.BranchOffices;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.FinanceRepositories.BranchOfficeRepositories;
    using X.PagedList;
    using static AutoMapper.Mapper;

    public class BranchOfficeAppService
    {
        private readonly IBranchOfficeRepository branchOfficeRepository;

        public BranchOfficeAppService(IBranchOfficeRepository branchOfficeRepository)
        {
            this.branchOfficeRepository = branchOfficeRepository;
        }

        public IPagedList<BranchOfficeViewModel> PageList(string searchString, int page, int size)
        {
            var entityList = branchOfficeRepository.PageList(searchString, page, size);

            return Map<IPagedList<BranchOfficeViewModel>>(entityList);
        }

        public BranchOfficeViewModel Get(Guid branchOfficeId)
        {
            var entity = branchOfficeRepository.Get(branchOfficeId);

            return Map<BranchOfficeViewModel>(entity);
        }

        public void Create(BranchOfficeViewModel model)
        {
            var entity = Map<BranchOffice>(model);

            branchOfficeRepository.Create(entity);
            branchOfficeRepository.Commit();
        }

        public void Modify(BranchOfficeViewModel model)
        {
            model.Id = model.Id ?? Guid.Empty;

            var entity = branchOfficeRepository.Get(model.Id.Value);

            if (entity == default(BranchOffice))
            {
                throw new ArgumentAppException(message: "参数错误");
            }

            Map(model, entity);

            branchOfficeRepository.Modify(entity);
            branchOfficeRepository.Commit();
        }

        public void Remove(Guid branchOfficeId)
        {
            var entity = branchOfficeRepository.Get(branchOfficeId);

            if (entity == default(BranchOffice))
            {
                throw new ArgumentAppException(message: "参数错误");
            }

            branchOfficeRepository.Remove(entity);
            branchOfficeRepository.Commit();
        }
    }
}
