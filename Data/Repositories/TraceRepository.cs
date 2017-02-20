namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities.CreditInvestigation;
    using Core.Interfaces.Repositories;

    public class TraceRepository : BaseRepository<Trace>, ITraceRepostitory
    {
        public TraceRepository(MyContext context) : base(context)
        {
        }

        int ITraceRepostitory.CountByDateCreatedAndReference(DateTime dateCreated, Guid referenceId, TraceTypeEnum traceType) =>
           GetAll().Count(m => m.ReferenceId == referenceId && m.DateCreated == dateCreated && m.Type == traceType);

        IEnumerable<Trace> ITraceRepostitory.GetByDateCreated(DateTime dateCreated) =>
           GetAll(m => m.DateCreated == dateCreated);

        IEnumerable<Trace> ITraceRepostitory.GetByIds(IEnumerable<Guid> traceIds) =>
            GetAll(m => traceIds.Contains(m.Id));

        IEnumerable<Trace> ITraceRepostitory.GetPageList(string search, int page, int size, TraceStatusEmum? status, DateTime? beginTime, DateTime? endTime)
        {
            var messageTrack = GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                messageTrack = messageTrack.Where(m => m.Name.Contains(search));
            }

            if (status.HasValue)
            {
                messageTrack = messageTrack.Where(m => m.Status == status);
            }

            // 开始日期筛选
            if (beginTime.HasValue)
            {
                messageTrack = messageTrack.Where(m => m.SpecialDate >= beginTime);
            }

            // 结束日期筛选
            if (endTime.HasValue)
            {
                messageTrack = messageTrack.Where(m => m.SpecialDate <= endTime);
            }

            messageTrack = messageTrack.OrderBy(m => m.Status).ThenByDescending(m => m.SpecialDate);

            return messageTrack;
        }
    }
}
