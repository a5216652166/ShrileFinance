namespace Core.Interfaces.Repositories.DatagramRepositories
{
    using System;
    using System.Collections.Generic;
    using Entities.CreditInvestigation;

    public interface ITraceRepostitory : IRepository<Trace>
    {
        /// <summary>
        /// 根据跟踪日期和引用标识获取数量
        /// </summary>
        /// <param name="dateCreated">报文创建日期</param>
        /// <param name="referenceId">引用标识</param>
        /// <param name="traceType">操作类型</param>
        /// <returns></returns>
        int CountByDateCreatedAndReference(DateTime dateCreated, Guid referenceId, TraceTypeEnum traceType);

        /// <summary>
        /// 获取跟踪集合根据报文创建日期
        /// </summary>
        /// <param name="dateCreated">报文创建日期</param>
        /// <returns></returns>
        IEnumerable<Trace> GetByDateCreated(DateTime dateCreated);

        /// <summary>
        /// 获取跟踪集合根据标识集合
        /// </summary>
        /// <param name="traceIds">标识集合</param>
        /// <returns></returns>
        IEnumerable<Trace> GetByIds(IEnumerable<Guid> traceIds);

        /// <summary>
        /// 根据筛选信息获取报文追踪列表
        /// </summary>
        /// <param name="search">搜索关键字</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <param name="status">报文状态</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">截至日期</param>
        /// <returns></returns>
        IEnumerable<Trace> GetPageList(string search, int page, int size, TraceStatusEmum? status = null, DateTime? beginTime = null, DateTime? endTime = null);
    }
}
