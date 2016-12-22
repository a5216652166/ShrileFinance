namespace Application
{
    using System;
    using System.Data;
    using System.IO;
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
                // 生成序列号
                var serialNumberGenerator = SerialNumberGenerator.GetInstance(() => repository.MaxSerialNumberByTraceDate(DateTime.Now.Date));
                var serialNumber = serialNumberGenerator.GetNext();

                var messageTrack = new Trace(referenceId, traceType, serialNumber, defaultName);

                repository.Create(messageTrack);
                repository.Commit();
            }
        }

        /// <summary>
        /// 下载单个报文文件
        /// </summary>
        /// <param name="id">报文标识</param>
        /// <returns>报文文件</returns>
        public FileInfo Download(Guid id)
        {
            var trace = repository.Get(id);

            if (trace == null)
            {
                throw new Exception("该报文不存在");
            }

            return trace.ToFile();
        }

        /// <summary>
        /// 生成昨日的报文
        /// </summary>
        public void Generate()
        {
            var lastDate = DateTime.Now.Date.AddDays(-1);
            var traces = repository.GetByTraceDate(lastDate);

            factory.Generate(traces);
        }

        public void GenerateTest()
        {
            var lastDate = DateTime.Now.Date;
            var traces = repository.GetByTraceDate(lastDate).Skip(3).Take(1);

            try
            {
                var trace = traces.First();
                factory.Generate(traces);

                repository.Commit();

                var file = trace.ToFile();
            }
            catch (Exception ex)
            {
                throw;
            }
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
