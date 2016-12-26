namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.CreditInvestigation;
    using Core.Interfaces.Repositories;
    using Core.Services.CreditInvestigation;
    using Infrastructure.File;
    using ViewModels.CreditInvesitigation.TraceViewModels;
    using X.PagedList;

    /// <summary>
    /// 报文应用服务
    /// </summary>
    public class DatagramAppService
    {
        private readonly ITraceRepostitory repository;
        private readonly IDatagramFileRepository datagramRepository;
        private readonly DatagramFactoryService factory;

        public DatagramAppService(ITraceRepostitory repository, IDatagramFileRepository datagramRepository, DatagramFactoryService factory)
        {
            this.repository = repository;
            this.datagramRepository = datagramRepository;
            this.factory = factory;
        }

        /// <summary>
        /// 报文追踪
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="traceType">操作类型</param>
        /// <param name="specialDate">业务发生日期</param>
        /// <param name="defaultName">默认名称</param>
        public void Trace(Guid referenceId, TraceTypeEnum traceType, DateTime specialDate, string defaultName = null)
        {
            var dateCreated = DateTime.Now.Date;
            var count = repository.CountByDateCreatedAndReference(dateCreated, referenceId);

            if (count == 0)
            {
                // 生成序列号
                var serialNumber = repository.MaxSerialNumberByDateCreated(dateCreated) + 1;
                var trace = new Trace(referenceId, traceType, serialNumber, specialDate, defaultName);

                repository.Create(trace);
                repository.Commit();
            }
        }

        public KeyValuePair<string, MemoryStream> DownloadZip(DownloadViewModel model)
        {
            var traces = repository.GetByIds(model.Ids);

            var files = new Dictionary<string, MemoryStream>();

            foreach (var trace in traces)
            {
                var file = trace.ToFile();
                files.Add(file.Key, (MemoryStream)file.Value);
            }

            return new KeyValuePair<string, MemoryStream>($"企业征信{DateTime.Now.ToString("yyyyMMdd")}.zip", FileHelper.Compression(files));
        }

        /// <summary>
        /// 下载单个报文文件
        /// </summary>
        /// <param name="id">报文标识</param>
        /// <returns>报文文件</returns>
        public KeyValuePair<string, Stream> Download(Guid id)
        {
            var trace = repository.Get(id);

            return trace.ToFile();
        }

        /// <summary>
        /// 下载单个报文文件
        /// </summary>
        /// <param name="id">报文标识</param>
        /// <returns>报文文件</returns>
        public KeyValuePair<string, byte[]> DownloadSingle(Guid id)
        {
            var trace = repository.Get(id);

            return trace.ToBytes();
        }

        /// <summary>
        /// 生成指定报文
        /// </summary>
        /// <param name="traceIds">追踪标识集合</param>
        public void Generate(IEnumerable<Guid> traceIds)
        {
            var traces = repository.GetByIds(traceIds);

            // 移除已生成的报文
            foreach (var trace in traces)
            {
                if (trace.DatagramFile != null)
                {
                    datagramRepository.Remove(trace.DatagramFile);
                }

                // 生成报文
                var datagramFile = factory.Generate(trace);

                // 添加文件
                trace.AddDatagram(datagramFile);
            }

            repository.Commit();
        }

        /// <summary>
        /// 获取报文跟踪列表
        /// </summary>
        /// <param name="search">搜索条件</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <returns></returns>
        public IPagedList<TraceViewModel> GetPageList(string search, int page, int size, TraceStatusEmum? status = null)
        {
            var messageTrack = repository.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                messageTrack = messageTrack.Where(m => m.Name.Contains(search));
            }

            if (status != null)
            {
                messageTrack = messageTrack.Where(m => m.Status == status.Value);
            }

            messageTrack = messageTrack.OrderBy(m => m.Status).ThenByDescending(m => m.SpecialDate);
            var pageList = messageTrack.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<TraceViewModel>>(pageList);

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
