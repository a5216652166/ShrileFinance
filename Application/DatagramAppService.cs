namespace Application
{
    using System;
    using System.Data;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.CreditInvestigation;
    using Core.Interfaces.Repositories;
    using Core.Services.CreditInvestigation;
    using ViewModels.CreditInvesitigation.TraceViewModels;
    using ViewModels.Message;
    using X.PagedList;

    /// <summary>
    /// 报文应用服务
    /// </summary>
    public class DatagramAppService
    {
        private readonly ITraceRepostitory repository;
        private readonly DatagramFactoryService factory;

        public DatagramAppService(ITraceRepostitory repository, DatagramFactoryService factory)
        {
            this.repository = repository;
            this.factory = factory;
        }

        /// <summary>
        /// 报文追踪
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="traceType">操作类型</param>
        /// <param name="defaultName">默认名称</param>
        public void Trace(Guid referenceId, TraceTypeEnum traceType, string defaultName = null)
        {
            var count = repository.CountByTraceDateAndReference(DateTime.Now.Date, referenceId);

            if (count == 0)
            {
                // var serialNumber = SerialNumberGenerator.GetInstance(() => respository.Get()).GetNext();
                messageTrack = new Trace(referenceId, traceType, defaultName);

                repository.Create(messageTrack);
                repository.Commit();
            }
        }

        public void Generate()
        {
            var traces = repository.GetByTraceDate(DateTime.Now.Date);

            factory.Generate(traces);
        }

        /// <summary>
        /// 获取报文跟踪列表
        /// </summary>
        /// <param name="search">搜索条件</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <returns></returns>
        public IPagedList<MessageTrackViewModel> GetPageList(string search, int page, int size)
        {
            var messageTrack = repository.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                messageTrack = messageTrack.Where(m => m.Name.Contains(search));
            }

            messageTrack = messageTrack.OrderByDescending(m => m.Id);
            var pageList = messageTrack.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<MessageTrackViewModel>>(pageList);

            return models;
        }

        /// <summary>
        /// 修改名称后保存(修改Name)
        /// </summary>
        /// <param name="model">视图模型</param>
        public void ModifyName(ModifyNameViewModel model)
        {
            var trace = repository.Get(model.Id);

            trace.Name = model.Name;

            repository.Modify(trace);
            repository.Commit();
        }
    }
}
