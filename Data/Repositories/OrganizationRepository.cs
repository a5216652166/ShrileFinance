namespace Data.Repositories
{
    using System.Data;
    using System.Data.SqlClient;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories;

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        private static  MyContext contexts;

        public OrganizationRepository(MyContext context) : base(context)
        {
            contexts = context;
        }


        public static DataTable AdministrativeDivision()
        {
            string sql = @"SSELECT* FROM BankCreditPlatform.BANK_Administration";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = contexts.Database.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new System.Data.DataTable();

            adapter.Fill(dt);

            return dt;
        }
    }
}
