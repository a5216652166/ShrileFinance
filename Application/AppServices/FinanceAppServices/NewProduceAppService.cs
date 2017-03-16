namespace Application.AppServices.FinanceAppServices
{
    using System;
    using Application.ViewModels.FinanceViewModels.ProduceViewModels;
    using AutoMapper;
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using X.PagedList;
    using System.Linq;

    public class NewProduceAppService
    {
        private readonly INewProduceRepository produceRepository;

        public NewProduceAppService(INewProduceRepository produceRepository)
        {
            this.produceRepository = produceRepository;
        }

        public IPagedList<NewProduceListViewModel> GetPageList(string search, int page, int rows)
        {
            var entityList = produceRepository.ProduceList(search, page, rows);

            var models = Mapper.Map<IPagedList<NewProduceListViewModel>>(entityList);


            return models;
        }

        public NewProduceViewModel Get(Guid produceId)
        {
            var entity = produceRepository.Get(produceId);

            if (entity == null)
            {
                throw new ArgumentException("参数无效");
            }

            return Mapper.Map<NewProduceViewModel>(entity);
        }

        public void Create(NewProduceViewModel model)
        {
            model.CreatedDate = DateTime.Now;

            model.RepayPrincipals = string.Join("-", model.RepayPrincipal.ToArray());

            var entity = Mapper.Map<NewProduce>(model);

            entity.Valid();

            produceRepository.Create(entity);

            produceRepository.Commit();
        }

        public void Modify(NewProduceViewModel model)
        {
            var entity = produceRepository.Get(model.Id);

            Mapper.Map(model, entity);

            produceRepository.Modify(entity);
        }
    }
}
