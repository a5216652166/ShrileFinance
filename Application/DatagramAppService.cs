namespace Application
{
    using System;
    using System.Collections.Generic;
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
        private readonly ITraceRepostitory traceRepository;
        private readonly IDatagramFileRepository datagramFileRepository;
        private readonly DatagramFactoryService factory;

        public DatagramAppService(
            ITraceRepostitory traceRepository,
            IDatagramFileRepository datagramFileRepository,
            DatagramFactoryService factory)
        {
            this.traceRepository = traceRepository;
            this.datagramFileRepository = datagramFileRepository;
            this.factory = factory;
        }

        /// <summary>
        /// 报文追踪
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="traceType">操作类型</param>
        /// <param name="specialDate">业务发生日期</param>
        /// <param name="organizateName">机构</param>
        /// <param name="defaultName">默认名称</param>
        public void Trace(Guid referenceId, TraceTypeEnum traceType, DateTime specialDate, string organizateName, string defaultName = null)
        {
            var dateCreated = DateTime.Now.Date;
            var count = traceRepository.CountByDateCreatedAndReference(dateCreated, referenceId, traceType);

            if (count == 0)
            {
                var trace = new Trace(referenceId, traceType, specialDate, organizateName, defaultName);

                traceRepository.Create(trace);
                traceRepository.Commit();
            }
        }

        /// <summary>
        /// 下载报文Zip
        /// </summary>
        /// <param name="model">报文下载Model</param>
        /// <returns>报文（名称-内存流）</returns>
        public KeyValuePair<string, byte[]> Download(DownloadViewModel model)
        {
            var traces = traceRepository.GetByIds(model.Ids);

            var files = new Dictionary<string, byte[]>();

            foreach (var trace in traces)
            {
                if (trace.DatagramFiles.Count == 0)
                {
                    trace.AddDatagram(factory.Generate(trace));

                    traceRepository.Modify(trace);
                    traceRepository.Commit();
                }

                foreach (var datagramFile in trace.DatagramFiles)
                {
                    var filename = datagramFile.GenerateFilename();
                    var buffer = datagramFile.GetBuffer();

                    files.Add(filename, buffer);
                    trace.FileName = filename;
                    traceRepository.Modify(trace);
                }
            }

            traceRepository.Commit();

            // 压缩打包
            var compressionBytes = FileHelper.ZipArchiveCompression(files);
            var compression = new KeyValuePair<string, byte[]>(
                $"企业征信{DateTime.Now.ToString("yyyyMMdd")}.zip",
                compressionBytes);

            return compression;
        }

        /// <summary>
        /// 生成指定报文
        /// </summary>
        /// <param name="traceIds">追踪标识集合</param>
        public void Generate(IEnumerable<Guid> traceIds)
        {
            var traces = traceRepository.GetByIds(traceIds);

            // 移除已生成的报文
            foreach (var trace in traces)
            {
                trace.DatagramFiles.ToList().ForEach(file =>
                {
                    datagramFileRepository.Remove(file);
                });

                // 添加文件
                trace.AddDatagram(factory.Generate(trace));
            }

            traceRepository.Commit();
        }

        /// <summary>
        /// 重生成指定报文
        /// </summary>
        /// <param name="traceIds">追踪标识集合</param>
        public void Rebuid(IEnumerable<Guid> traceIds)
        {
            var traces = traceRepository.GetByIds(traceIds);
            traceRepository.GetByIds(traceIds).ToList().ForEach(trace =>
            {
                trace.DatagramFiles.ToList().ForEach(file =>
                {
                    datagramFileRepository.Remove(file);
                });

                // 添加报文
                trace.AddDatagram(factory.Generate(trace));

                traceRepository.Commit();
            });
        }

        /// <summary>
        /// 获取报文跟踪列表
        /// </summary>
        /// <param name="search">搜索条件</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <param name="status">报文状态</param>
        /// <param name="beginTime">起始日期</param>
        /// <param name="endTime">截至日期</param>
        /// <returns></returns>
        public IPagedList<TraceViewModel> GetPageList(string search, int page, int size, TraceStatusEmum? status = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var messageTrack = traceRepository.GetPageList(search, page, size, status, beginTime, endTime);

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
            var trace = traceRepository.Get(model.Id);

            trace.Name = model.Name;

            traceRepository.Modify(trace);
            traceRepository.Commit();
        }
    }
}
