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

        public int CountByTraceDateAndReference(DateTime traceDate, Guid referenceId)
        {
            return GetAll().Count(m => m.TraceDate == traceDate && m.ReferenceId == referenceId);
        }

        public int MaxSerialNumberByTraceDate(DateTime traceDate)
        {
            return GetByTraceDate(traceDate).Max(m => m.SerialNumber);
        }

        public IEnumerable<Trace> GetByTraceDate(DateTime traceDate)
        {
            return GetAll(m => m.TraceDate == traceDate);
        }
    }
}
