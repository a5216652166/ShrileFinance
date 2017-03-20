namespace Application.AppServices.FinanceAppServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.ViewModels.FinanceViewModels.ProduceViewModels;
    using AutoMapper;
    using Core.Entities.Finance;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using X.PagedList;

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

            return Mapper.Map<IPagedList<NewProduceListViewModel>>(entityList);
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
            model.RepayPrincipals = string.Join("-", model.RepayPrincipal.ToArray());

            var entity = Mapper.Map<NewProduce>(model);

            entity.SetCreatedDate();

            entity.Valid();

            Valid(entity.Code);

            produceRepository.Create(entity);

            produceRepository.Commit();

            void Valid(string code)
            {
                var exception = default(Exception);

                var count = produceRepository.GetAll(m => m.Code == code).Count();

                if (count > 0)
                {
                    exception = new ArgumentOutOfRangeAppException(message: $"已存在该产品代码{code}");
                }

                if (exception != default(Exception))
                {
                    throw exception;
                }
            }
        }

        public IEnumerable<KeyValuePair<Guid, string>> Options()
            => produceRepository.GetAll().OrderByDescending(m => m.CreatedDate).Select(m => new KeyValuePair<Guid, string>(m.Id, m.Code)).AsEnumerable();

        public void Modify(NewProduceViewModel model)
        {
            var entity = produceRepository.Get(model.Id);

            model.RepayPrincipals = string.Join("-", model.RepayPrincipal.ToArray());

            Mapper.Map(model, entity);

            entity.Valid();

            Valid(entity.Code, entity.Id);

            produceRepository.Modify(entity);

            produceRepository.Commit();

            void Valid(string code, Guid id)
            {
                var exception = default(Exception);

                var count = produceRepository.GetAll(m => m.Code == code && m.Id != id).Count();

                if (count > 0)
                {
                    exception = new ArgumentOutOfRangeAppException(message: $"已存在该代码{code}");
                }

                if (exception != default(Exception))
                {
                    throw exception;
                }
            }
        }
    }
}
