namespace Application.Produce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Produce;
    using ProduceViewModels;
    using X.PagedList;

    public class ProduceAppService
    {
        private readonly IProduceRepository repository;

        public ProduceAppService(IProduceRepository repository)
        {
            this.repository = repository;
        }

        public IPagedList<ProduceViewModel> PagedList(string searchString, int page, int size)
        {
            var produces = repository.List(searchString, page, size);

            var models =
                Mapper.Map<IPagedList<ProduceViewModel>>(produces);

            return models;
        }

        public IEnumerable<ProduceViewModel> Options()
        {
            var produces = repository.GetAll();

            var options =
                Mapper.Map<IEnumerable<ProduceViewModel>>(produces);

            return options;
        }

        public ProduceViewModel Get(Guid id)
        {
            var entity = repository.Get(id);

            var model = Mapper.Map<ProduceViewModel>(entity);

            return model;
        }

        public Guid Create(ProduceBindModel model)
        {
            var searchByCode =
                repository.GetAll(m => m.Code == model.Code);

            if (searchByCode.Count() > 0)
            {
                throw new ArgumentException(message: $"产品已存在.");
            }

            var entity = Mapper.Map<Produce>(model);

            repository.Create(entity);
            repository.Commit();

            return entity.Id;
        }

        public void Modify(ProduceBindModel model)
        {
            var entity = repository.Get(model.Id);

            Mapper.Map(model, entity);

            repository.Modify(entity);
            repository.Commit();
        }
    }
}
