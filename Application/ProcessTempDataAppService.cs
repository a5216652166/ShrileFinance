namespace Application
{
    using System;
    using System.Linq;
    using Core.Entities;
    using Core.Entities.Process;
    using Core.Interfaces.Repositories;
    using ViewModels.ProcessViewModels;

    public class ProcessTempDataAppService
    {
        private readonly IProcessTempDataRepository processTempDataRepository;
        private readonly IInstanceRepository instanceRepository;

        public ProcessTempDataAppService(
            IProcessTempDataRepository processTempDataRepository,
            IInstanceRepository instanceRepository)
        {
            this.processTempDataRepository = processTempDataRepository;
            this.instanceRepository = instanceRepository;
        }

        public ProcessTempDataViewModel<T> GetByInstanceId<T>(Guid instanceId) where T : class
        {
            var processTempDataViewModel = default(ProcessTempDataViewModel<T>);

            var processTempDatas = processTempDataRepository.GetAll(m => m.InstanceId == instanceId);

            if (processTempDatas.Count() > 0)
            {
                var processTempData = processTempDatas.Single();

                processTempDataViewModel = new ProcessTempDataViewModel<T>()
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

        public void Create<T>(ProcessTempDataViewModel<T> processTempDataViewModel) where T : class
        {
            if (processTempDataViewModel.InstanceId == Guid.Empty || processTempDataViewModel.ObjData == null)
            {
                return;
            }

            var processTempData = new ProcessTempData()
            {
                InstanceId = processTempDataViewModel.InstanceId
            };

            processTempData.ConvertToJsonData(processTempDataViewModel.ObjData);

            processTempDataRepository.RemoveOldEntity(processTempData.Id);

            processTempDataRepository.Create(processTempData);
        }

        public void Modify<T>(ProcessTempDataViewModel<T> processTempDataViewModel) where T : class
        {
            var processTempData = processTempDataRepository.Get(processTempDataViewModel.Id);

            if (processTempData == null)
            {
                throw new ArgumentException("流程临时数据实例不存在");
            }

            processTempData.InstanceId = processTempDataViewModel.InstanceId;

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
