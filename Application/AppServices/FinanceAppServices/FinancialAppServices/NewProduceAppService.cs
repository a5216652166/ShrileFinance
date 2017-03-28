namespace Application.AppServices.FinanceAppServices.FinancialAppServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Finance.Financial;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.FinanceRepositories.FinancialRepositories;
    using ViewModels.FinanceViewModels.FinancialLoanViewModels;
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

            var model = Mapper.Map<NewProduceViewModel>(entity);

            model.ParseRepayPrincipal();

            return model;
        }

        public void Create(NewProduceViewModel model)
        {
            model.RepayPrincipals = string.Join("-", model.RepayPrincipal.ToArray());

            var entity = Mapper.Map<Produce>(model);

            entity.AllowCreatedDate();

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

        public void Modify(NewProduceViewModel model)
        {
            var entity = produceRepository.Get(model.Id.Value);

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

        public IEnumerable<RepayTableViewModel> LoadRepayTable(Guid produceId, decimal pV)
        {
            var repayTables = default(IEnumerable<RepayTable>);

            var produce = produceRepository.Get(produceId);

            if (produce == null)
            {
                throw new ArgumentNullAppException(message: "产品为空！");
            }
            else if (pV > 0)
            {
                repayTables = produce.CalculateRepayTable(pV);
            }
            else
            {
                repayTables = new HashSet<RepayTable>();
            }

            return Mapper.Map<IEnumerable<RepayTableViewModel>>(repayTables);
        }

        public IEnumerable<KeyValuePair<Guid, string>> Options()
            => produceRepository.GetAll().OrderByDescending(m => m.CreatedDate).Select(m => new KeyValuePair<Guid, string>(m.Id, m.Code)).AsEnumerable();
    }
}
