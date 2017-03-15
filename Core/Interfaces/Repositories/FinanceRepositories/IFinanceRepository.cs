namespace Core.Interfaces.Repositories
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using Entities.Finance;

    /// <summary>
    /// 融资仓储
    /// </summary>
    public interface IFinanceRepository : IRepository<Finance>
    {
        DataTable LeaseeContract(SqlParameter[] parameters);
    }
}
