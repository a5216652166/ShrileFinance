namespace Core.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using Entities.CreditInvestigation;

    public interface ITraceRepostitory : IRepository<Trace>
    {
        int CountByTraceDateAndReference(DateTime traceDate, Guid referenceId);

        int MaxSerialNumberByTraceDate(DateTime traceDate);

        IEnumerable<Trace> GetByTraceDate(DateTime traceDate);
    }
}
