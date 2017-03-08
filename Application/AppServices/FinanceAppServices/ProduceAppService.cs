namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Produce;
    using Core.Interfaces.Repositories;
    using ViewModels;
    using ViewModels.ProduceViewModel;
    using X.PagedList;

    public class ProduceAppService
    {
        private readonly IProduceRepository repository;
        private readonly IFinancingProjectRepository projectRepository;
        private readonly AppUserManager userManager;
        private readonly IPartnerRepository partnerRepository;

        public ProduceAppService(IProduceRepository repository, IFinancingProjectRepository projectRepository, AppUserManager userManager, IPartnerRepository partnerRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
            this.userManager = userManager;
            this.partnerRepository = partnerRepository;
        }

        public ProduceViewModel Get(Guid id)
        {
            Produce produce = repository.Get(id);
            var produceViewModel = Mapper.Map<ProduceViewModel>(produce);

            return produceViewModel;
        }

        public void Create(ProduceViewModel value)
        {
            var produce = Mapper.Map<Produce>(value);
            produce.FinancingItems = Mapper.Map<ICollection<FinancingItem>>(value.FinancingItems);
            if (value.Poundage != null)
            {
                foreach (var item in value.Poundage)
                {
                    var financingItem = Mapper.Map<FinancingItem>(item);

                    produce.FinancingItems.Add(financingItem);
                }
            }

            repository.Create(produce);
            repository.Commit();
        }

        public void Modify(ProduceViewModel model)
        {
            var produce = repository.Get(model.Id);
            Mapper.Map(model, produce);
            if (model.Poundage != null)
            {
                foreach (var item in model.Poundage)
                {
                    var financingItem = Mapper.Map<FinancingItem>(item);
                    model.FinancingItems.Add(item);
                }
            }

            if (model.FinancingItems.Count > 0)
            {
                new UpdateBind().Bind(produce.FinancingItems, model.FinancingItems);
            }

            repository.Modify(produce);
            repository.Commit();
        }

        public List<ProduceViewModel> GetAll()
        {
            var list = repository.GetAll();
            List<ProduceViewModel> producelist = new List<ProduceViewModel>();

            // 判断是否查询到产品信息
            if (list != null)
            {
                foreach (var item in list)
                {
                    // 产品映射成对应的ViewModel
                    var produceViewModel = Mapper.Map<ProduceViewModel>(item);

                    producelist.Add(produceViewModel);
                }
            }

            return producelist;
        }

        public ProduceViewModel GetByCode(string code)
        {
            var produce = repository.GetAll().FirstOrDefault(m => m.Code == code);
            var produceViewModel = new ProduceViewModel();
            List<FinancingProjectListViewModel> list = new List<FinancingProjectListViewModel>();

            produceViewModel = Mapper.Map<ProduceViewModel>(produce);

            if (produceViewModel != null)
            {
                if (produceViewModel.FinancingItems.Count > 0)
                {
                    foreach (var financing in produceViewModel.FinancingItems)
                    {
                        // 融资项否则为手续费项目
                        if (financing.FinancingProject.IsFinancing == false)
                        {
                            produceViewModel.PoundageList.Add(new FinancingProjectListViewModel()
                            {
                                FinancingProjectId = financing.FinancingProjectId,
                                IsEdit = financing.IsEdit,
                                IsFinancing = financing.FinancingProject.IsFinancing,
                                Money = financing.Money,
                                Name = financing.FinancingProject.Name
                            });
                        }
                        else
                        {
                            var produceModel = new FinancingProjectListViewModel()
                            {
                                FinancingProjectId = financing.FinancingProjectId,
                                IsEdit = financing.IsEdit,
                                IsFinancing = financing.FinancingProject.IsFinancing,
                                Money = financing.Money,
                                Name = financing.FinancingProject.Name
                            };
                            produceViewModel.FinancingItemsList.Add(produceModel);
                        }
                    }
                }
            }

            return produceViewModel;
        }

        public IPagedList<ProduceListViewModel> GetPageList(string serach, int pageNumber, int pageSize)
        {
            var produces = repository.GetAll();

            if (!string.IsNullOrEmpty(serach))
            {
                produces = produces.Where(m => m.Name.Contains(serach) || m.Code.Contains(serach));
            }

            produces = produces.OrderByDescending(m => m.Id);
            var pagedList = produces.ToPagedList(pageNumber, pageSize);

            var models = Mapper.Map<IPagedList<ProduceListViewModel>>(pagedList);

            return models;
        }
    }
}
