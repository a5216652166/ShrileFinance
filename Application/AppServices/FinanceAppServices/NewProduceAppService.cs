namespace Application.AppServices.FinanceAppServices
{
    using System;
    using Application.ViewModels.FinanceViewModels;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using X.PagedList;
    using AutoMapper;

    public class NewProduceAppService
    {
        private readonly INewProduceRepository produceRepository;

        public NewProduceAppService(INewProduceRepository produceRepository)
        {
            this.produceRepository = produceRepository;
        }

        public IPagedList<NewProduceListViewModel> GetPageList(string search, int page, int rows)
        {
            var modelList = produceRepository.ProduceList(search, page, rows);

            return Mapper.Map<IPagedList<NewProduceListViewModel>>(modelList);
        }
    }
}
