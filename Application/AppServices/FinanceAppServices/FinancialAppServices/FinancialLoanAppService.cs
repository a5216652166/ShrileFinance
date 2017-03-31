namespace Application.AppServices.FinanceAppServices.FinancialAppServices
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Finance.Financial;
    using Core.Exceptions;
    using Core.Interfaces.Repositories.FinanceRepositories.FinanceRepositories;
    using Core.Interfaces.Repositories.FinanceRepositories.FinancialRepositories;
    using ViewModels.FinanceViewModels.FinancialLoanViewModels;
    using X.PagedList;

    public class FinancialLoanAppService
    {
        private readonly IFinancialLoanRepository financialLoanRepository;
        private readonly IProduceRepository produceRepository;
        private readonly IFinancialItemRepository financialItemRepository;

        public FinancialLoanAppService(
            IFinancialLoanRepository financialLoanRepository,
            IProduceRepository produceRepository,
            IFinancialItemRepository financialItemRepository)
        {
            this.financialLoanRepository = financialLoanRepository;
            this.produceRepository = produceRepository;
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

            entity.Produce = produceRepository.Get(model.Produce.Id.Value);

            entity.AllowCreatedDate();

            DistinguishProduceLeaseType(entity, model);

            foreach (var item in model.FinancialItem)
            {
                entity.FinancialItem.Add(Mapper.Map<FinancialItem>(item));
            }

            entity.Valid();

            ValidLoanNum(entity.LoanNum);

            financialLoanRepository.Create(entity);

            foreach (var item in entity.FinancialItem)
            {
                financialItemRepository.Create(item);
            }

            financialLoanRepository.Commit();

            void ValidLoanNum(string name)
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

            DistinguishProduceLeaseType(entity, model);

            Mapper.Map(model, entity);

            entity.Produce = produceRepository.Get(model.Produce.Id.Value);

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

        private void DistinguishProduceLeaseType(FinancialLoan entity, FinancialLoanViewModel model)
        {
            if (entity.Produce.LeaseType == LeaseTypeEnum.回租)
            {
                entity.FinancialAmounts = model.FinancialAmounts;
            }
            else
            {
                entity.FinancialAmounts = entity.FinancialItem.Sum(m => m.FinancialAmount);
            }
        }
    }
}
