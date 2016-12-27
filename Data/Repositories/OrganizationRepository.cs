namespace Data.Repositories
{
    using System.Data;
    using System.Data.SqlClient;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories;

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        private readonly MyContext context;

        public OrganizationRepository(MyContext context) : base(context)
        {
            this.context = context;
        }

        public DataTable LeaseeContract(SqlParameter[] parameters)
        {
            string sql = @"SSELECT* FROM BankCreditPlatform.BANK_Administration";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Context.Database.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            if (parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new System.Data.DataTable();

            adapter.Fill(dt);

            return dt;
        }
    }
}
