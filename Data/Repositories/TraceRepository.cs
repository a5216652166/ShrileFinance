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

        public int CountByDateCreatedAndReference(DateTime dateCreated, Guid referenceId)
        {
            return GetAll().Count(m => m.ReferenceId == referenceId && m.SpecialDate ==dateCreated);
        }

        public int MaxSerialNumberByDateCreated(DateTime dateCreated)
        {
            var traces = GetByDateCreated(dateCreated);

            return traces.Any() ? traces.Max(m => m.SerialNumber) : 0;
        }

        public IEnumerable<Trace> GetByDateCreated(DateTime dateCreated)
        {
            return GetAll(m => m.SpecialDate ==dateCreated);
        }

        public IEnumerable<Trace> GetByIds(IEnumerable<Guid> traceIds)
        {
            return GetAll(m => traceIds.Contains(m.Id));
        }
    }
}
