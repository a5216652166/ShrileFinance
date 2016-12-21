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
        /// <param name="traceDate">跟踪日期</param>
        /// <param name="referenceId">引用标识</param>
        /// <returns></returns>
        int CountByTraceDateAndReference(DateTime traceDate, Guid referenceId);

        /// <summary>
        /// 获取最大的序列号跟去跟踪日期
        /// </summary>
        /// <param name="traceDate">跟踪日期</param>
        /// <returns></returns>
        int MaxSerialNumberByTraceDate(DateTime traceDate);

        /// <summary>
        /// 获取跟踪集合根据跟踪日期
        /// </summary>
        /// <param name="traceDate">跟踪日期</param>
        /// <returns></returns>
        IEnumerable<Trace> GetByTraceDate(DateTime traceDate);
    }
}
