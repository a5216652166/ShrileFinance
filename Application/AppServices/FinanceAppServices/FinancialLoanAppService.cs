namespace Application.AppServices.FinanceAppServices
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Finance;
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

            entity.Valid();

            Valid(entity.FinancialItem.Name);

            financialLoanRepository.Create(entity);

            financialItemRepository.Create(entity.FinancialItem);

            financialLoanRepository.Commit();

            void Valid(string name)
            {
                var exception = default(Exception);

                var count = financialLoanRepository.GetAll(m => m.FinancialItem.Name == name).Count();

                if (count > 0)
                {
                    exception = new ArgumentOutOfRangeAppException(message: $"已存在该融资项名称{name}");
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

            entity.Valid();

            Valid(entity.FinancialItem.Name, entity.Id);

            financialLoanRepository.Modify(entity);

            financialLoanRepository.Commit();

            void Valid(string name, Guid id)
            {
                var exception = default(Exception);

                var count = financialLoanRepository.GetAll(m => m.FinancialItem.Name == name && m.Id != id).Count();

                if (count > 0)
                {
                    exception = new ArgumentOutOfRangeAppException(message: $"已存在该融资项名称{name}");
                }

                if (exception != default(Exception))
                {
                    throw exception;
                }
            }
        }
    }
}
