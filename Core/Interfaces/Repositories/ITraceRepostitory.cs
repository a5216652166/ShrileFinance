namespace Core.Interfaces.Repositories
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
        /// <returns></returns>
        int CountByDateCreatedAndReference(DateTime dateCreated, Guid referenceId);

        /// <summary>
        /// 获取最大的序列号根据报文创建日期
        /// </summary>
        /// <param name="dateCreated">报文创建日期</param>
        /// <returns></returns>
        int MaxSerialNumberByDateCreated(DateTime dateCreated);

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
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="status">报文状态</param>
        /// <returns></returns>
        IEnumerable<Trace> GetPageList(string search, int page, int size, TraceStatusEmum? status = null);
    }
}
