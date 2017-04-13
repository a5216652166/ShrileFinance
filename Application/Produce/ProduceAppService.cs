namespace Application.Produce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Exceptions;
    using Core.Produce;
    using ProduceViewModels;
    using X.PagedList;

    public class ProduceAppService
    {
        private readonly IProduceRepository repository;
        private readonly PaymentEqualsCalculatorService paymentEqualsCalculatorService;

        public ProduceAppService(
            IProduceRepository repository,
            PaymentEqualsCalculatorService paymentEqualsCalculatorService)
        {
            this.repository = repository;
            this.paymentEqualsCalculatorService = paymentEqualsCalculatorService;
        }

        public IPagedList<ProduceViewModel> PagedList(string searchString, int page, int size)
        {
            var produces = repository.PagedList(searchString, page, size);

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
                throw new ArgumentAppException(message: $"产品已存在.");
            }

            var entity = Mapper.Map<Produce>(model);

            // 计算每年的月供系数, 本金 10000.
            YearlyPayment(entity, 10000);

            repository.Create(entity);
            repository.Commit();

            return entity.Id;
        }

        public void Modify(ProduceBindModel model)
        {
            var entity = repository.Get(model.Id.Value);

            Mapper.Map(model, entity);

            // 计算每年的月供系数, 本金 10000.
            YearlyPayment(entity, 10000);

            repository.Modify(entity);
            repository.Commit();
        }

        /// <summary>
        /// 计算每年的月供额
        /// </summary>
        /// <param name="produceId">产品标识</param>
        /// <param name="principal">融资总额</param>
        /// <returns></returns>
        public IEnumerable<PrincipalRatioViewModel> YearlyPayment(Guid produceId, decimal principal)
        {
            var produce = repository.Get(produceId);

            var payments = YearlyPayment(produce, principal);

            return Mapper.Map<IEnumerable<PrincipalRatioViewModel>>(payments);
        }

        /// <summary>
        /// 计算每年的月供额
        /// </summary>
        /// <param name="produce">产品</param>
        /// <param name="principal">融资总额</param>
        /// <returns></returns>
        private IEnumerable<PrincipalRatio> YearlyPayment(Produce produce, decimal principal)
        {
            var payments = paymentEqualsCalculatorService
                .YearlyPayment(produce.PrincipalRatios, principal, produce.RateMonth);

            return payments;
        }
    }
}
