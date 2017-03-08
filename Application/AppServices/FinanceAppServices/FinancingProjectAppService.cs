namespace Application
{
    using System.Collections.Generic;
    using Application.ViewModels.ProduceViewModel;
    using AutoMapper;
    using Core.Entities.Produce;
    using Core.Interfaces.Repositories;

    public class FinancingProjectAppService
    {
        private readonly IFinancingProjectRepository repository;

        public FinancingProjectAppService(IFinancingProjectRepository repository)
        {
            this.repository = repository;
        }

        public void Create(FinancingProjectViewModel value)
        {
            var financingProject = Mapper.Map<FinancingProject>(value);

            repository.Create(financingProject);
            repository.Commit();
        }

        public void Modify(FinancingProjectViewModel value)
        {
            var financingProject = Mapper.Map<FinancingProject>(value);

            repository.Modify(financingProject);
            repository.Commit();
        }

        public List<FinancingProjectListViewModel> GetAll()
        {
            var financingProjectList = repository.GetAll();
            List<FinancingProjectListViewModel> list = new List<FinancingProjectListViewModel>();
            if (financingProjectList != null)
            {
                foreach (var financingProject in financingProjectList)
                {
                    FinancingProjectListViewModel financinglist = new FinancingProjectListViewModel()
                    {
                        Name = financingProject.Name,
                        IsFinancing = financingProject.IsFinancing
                    };

                    list.Add(financinglist);
                }
            }

            return list;
        }

        public IEnumerable<FinancingProjectListViewModel> GetByIsFinancing(bool isFinancing)
        {
           var financingProjectList = repository.GetByIsFinacing(isFinancing);
           List<FinancingProjectListViewModel> list = new List<FinancingProjectListViewModel>();
            if (financingProjectList != null)
            {
                foreach (var financingProject in financingProjectList)
                {
                    FinancingProjectListViewModel financinglist = new FinancingProjectListViewModel()
                    {
                        FinancingProjectId = financingProject.Id,
                        Name = financingProject.Name,
                        IsFinancing = financingProject.IsFinancing
                    };

                    list.Add(financinglist);
                }
            }

            return list;
        }
    }
}
