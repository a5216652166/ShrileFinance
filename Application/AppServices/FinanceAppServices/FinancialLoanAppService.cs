namespace Application.AppServices.FinanceAppServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Finance.Financial;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using X.PagedList;

    public class FinancialLoanAppService
    {
        private readonly IFinancialLoanRepository financialLoanRepository;
        private readonly INewProduceRepository newProduceRepository;
        private readonly IFinancialItemRepository financialItemRepository;

        public FinancialLoanAppService(
            IFinancialLoanRepository financialLoanRepository,
            INewProduceRepository newProduceRepository,
            IFinancialItemRepository financialItemRepository)
        {
            this.financialLoanRepository = financialLoanRepository;
            this.newProduceRepository = newProduceRepository;
            this.financialItemRepository = financialItemRepository;
        }

        public IPagedList<FinancialLoanListViewModel> GetPageList(string searchString, int page, int size, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var entityList = financialLoanRepository.FinancialLoanList(searchString, page, size, beginTime, endTime);

            return Mapper.Map<IPagedList<FinancialLoanListViewModel>>(entityList);
        }

        public FinancialLoanViewModel Get(Guid produceId)
        {
            var entity = financialLoanRepository.Get(produceId);

            if (entity == null)
            {
                throw new ArgumentException("参数无效");
            }

            return Mapper.Map<FinancialLoanViewModel>(entity);
        }

        public void Create(FinancialLoanViewModel model)
        {
            var entity = Mapper.Map<FinancialLoan>(model);

            entity.SetProduce(newProduceRepository.Get(model.NewProduce.Id));

            entity.SetCreatedDate();

            foreach (var item in model.FinancialItem)
            {
                entity.FinancialItem.Add(Mapper.Map<FinancialItem>(item));
            }

            entity.Valid();

            Valid(entity.LoanNum);

            financialLoanRepository.Create(entity);

            foreach (var item in entity.FinancialItem)
            {
                financialItemRepository.Create(item);
            }

            financialLoanRepository.Commit();

            void Valid(string name)
            {
                var exception = default(Exception);

                var count = financialLoanRepository.GetAll(m => m.LoanNum == name).Count();

                if (count > 0)
                {
                    exception = new ArgumentOutOfRangeAppException(message: $"已存在该放款编号：{name}");
                }

                if (exception != default(Exception))
                {
                    throw exception;
                }
            }
        }

        public void Modify(FinancialLoanViewModel model)
        {
            var entity = financialLoanRepository.Get(model.Id);

            entity.SetProduce(newProduceRepository.Get(model.NewProduce.Id));

            Mapper.Map(model, entity);

            var removeFinancialItems = UpdateBind.BindCollection(entity.FinancialItem, model.FinancialItem);

            financialItemRepository.RemoveOldEntity(removeFinancialItems);

            entity.Valid();

            Valid(entity.LoanNum, entity.Id);

            financialLoanRepository.Modify(entity);

            financialLoanRepository.Commit();

            void Valid(string name, Guid id)
            {
                var exception = default(Exception);

                var count = financialLoanRepository.GetAll(m => m.LoanNum == name && m.Id != id).Count();

                if (count > 0)
                {
                    exception = new ArgumentOutOfRangeAppException(message: $"已存在该放款编号：{name}");
                }

                if (exception != default(Exception))
                {
                    throw exception;
                }
            }
        }
    }
}
