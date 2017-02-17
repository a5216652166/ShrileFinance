namespace Application
{
    using System;
    using System.Linq;
    using Core.Entities;
    using Core.Interfaces.Repositories;
    using ViewModels.ProcessViewModels;

    public class ProcessTempDataAppService
    {
        private readonly IProcessTempDataRepository processTempDataRepository;

        public ProcessTempDataAppService(IProcessTempDataRepository processTempDataRepository)
        {
            this.processTempDataRepository = processTempDataRepository;
        }

        public ProcessTempDataViewModel GetByInstanceId<T>(Guid instanceId) where T : class
        {
            var processTempDataViewModel = default(ProcessTempDataViewModel);

            var processTempDatas = processTempDataRepository.GetAll(m => m.InstanceId == instanceId);

            if (processTempDatas.Count() > 0)
            {
                var processTempData = processTempDatas.Single();

                processTempDataViewModel = new ProcessTempDataViewModel()
                {
                    Id = processTempData.Id,
                    InstanceId = processTempData.InstanceId,
                    JsonData = processTempData.JsonData,
                    Instance = processTempData.Instance,
                    ObjData = processTempData.ConvertToObject<T>()
                };
            }

            return processTempDataViewModel;
        }

        public void Create(ProcessTempDataViewModel processTempDataViewModel)
        {
            if (processTempDataViewModel.InstanceId == Guid.Empty || processTempDataViewModel.ObjData == null)
            {
                return;
            }

            var processTempData = new ProcessTempData()
            {
                InstanceId = processTempDataViewModel.InstanceId,
                Instance = processTempDataViewModel.Instance
            };

            processTempData.ConvertToJsonData(processTempDataViewModel.ObjData);

            var obj = processTempDataRepository.GetAll(m => m.InstanceId == processTempDataViewModel.InstanceId);
            if (obj.Count() > 0)
            {
                processTempDataRepository.Remove(obj.Single());
            }

            processTempDataRepository.Create(processTempData);
        }

        public void Modify(ProcessTempDataViewModel processTempDataViewModel)
        {
            var processTempData = processTempDataRepository.GetAll(m => m.InstanceId == processTempDataViewModel.InstanceId).Single();

            processTempData.ConvertToJsonData(processTempDataViewModel.ObjData);

            processTempDataRepository.Modify(processTempData);
        }

        public void Remove(Guid id)
        {
            var processTempData = processTempDataRepository.Get(id);

            if (processTempData != null)
            {
                processTempDataRepository.Remove(processTempData);
            }
        }
    }
}
