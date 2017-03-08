namespace Data.Repositories
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories;
    using Infrastructure.PDF;

    public class FinanceRepository : BaseRepository<Finance>, IFinanceRepository
    {
        private readonly MyContext context;

        public FinanceRepository(MyContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// 融资租赁合同
        /// </summary>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataTable LeaseeContract(SqlParameter[] parameters)
        {
            string sql = @"SELECT rz.Number AS '[融资租赁合同]', rz.Number AS '[担保合同]',  
                 ma.Name AS '[乙方姓名]', ma.[Identity] AS '[乙方证件号码]',
                 ja.Name AS '[共借人姓名]', ja.[Identity] AS '[共借人证件号码]',
                 fv.PlateNo AS '[车牌号]', fv.FrameNo AS '[车架号]', fv.EngineNo AS '[发动机号]', fv.RunningMiles AS '[里程数]',
                 ch.CarBrand AS '[品牌]', ch.Series AS '[型号]',
                 '' AS '[融资额大写]', fi.Principal AS '[融资额]', 
                 pi.FinancingPeriods AS '[融资期限]', '' AS '[手续费大写]', fi.Poundage AS '[手续费]',
                 '' AS '[保证金大写]',  fi.Bail AS '[保证金]',
                 fi.RepaymentDate AS '[号]',
                 YEAR(DATEADD(MM, 1, fi.RepayRentDate)) AS '[年]', MONTH(DATEADD(MM, 1, fi.RepayRentDate)) AS '[月]', DAY(DATEADD(MM, 1, fi.RepayRentDate)) AS '[日]',
                 fe.CustomerAccountName AS '[户名]', fe.CustomerBankName AS '[乙方开户行地址]', fe.CustomerBankCard AS '[乙方开户行账号]'
                FROM FANC_Finance AS fi
                LEFT JOIN PROD_Produce AS pi ON fi.ProduceId = pi.Id
                LEFT JOIN FANC_Vehicle AS fv ON fv.FinanceId = fi.Id
                LEFT JOIN FANC_FinanceExtension AS fe ON fe.FinanceId = fi.Id
                LEFT JOIN(
                    SELECT ai.FinanceId, ai.Name, ai.[Identity]
                    FROM FANC_Applicant AS ai
                    WHERE ai.FinanceId = @financeId AND Type = 1
                ) AS ma ON ma.FinanceId = fi.Id
                LEFT JOIN(
                   SELECT ai.FinanceId, ai.Name, ai.[Identity]
                    FROM FANC_Applicant AS ai
                    WHERE ai.FinanceId = @financeId AND Type = 2
                ) AS ja ON ja.FinanceId = fi.Id
               LEFT JOIN V_CarHome AS ch ON fv.VehicleKey  = ch.VehicleCode
               LEFT JOIN(
                SELECT Number, FinanceId FROM FANC_Contact AS fc WHERE fc.FinanceId = @financeId AND Name = '融资租赁合同'
               ) AS rz ON rz.FinanceId = fi.Id
               LEFT JOIN(
                SELECT Number, FinanceId FROM FANC_Contact AS fc WHERE fc.FinanceId = @financeId AND Name = '保证合同'
               )AS bz ON bz.FinanceId = fi.Id
               WHERE fi.Id = @financeId";
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = context.Database.Connection.ConnectionString;
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
            DataTable dt = new DataTable();
            MoneyToUpper moneyToUpper = new MoneyToUpper();

            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                string approvalPrincipal = string.IsNullOrEmpty(dr["[融资额]"].ToString()) ? "0" : dr["[融资额]"].ToString();
                dr["[融资额大写]"] = moneyToUpper.RMBToUpper(Convert.ToDecimal(approvalPrincipal), 2);
                dr["[融资额]"] = Math.Round(Convert.ToDecimal(approvalPrincipal), 2);

                string customerPoundage = string.IsNullOrEmpty(dr["[手续费]"].ToString()) ? "0" : dr["[手续费]"].ToString();
                dr["[手续费大写]"] = moneyToUpper.RMBToUpper(Convert.ToDecimal(customerPoundage), 2);
                dr["[手续费]"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(customerPoundage)), 2);

                string ensurePrice = string.IsNullOrEmpty(dr["[保证金]"].ToString()) ? "0" : dr["[保证金]"].ToString();
                dr["[保证金大写]"] = moneyToUpper.RMBToUpper(ensurePrice, 2);
                dr["[保证金]"] = Math.Round(Convert.ToDecimal(ensurePrice), 2);
            }

            return dt;
        }
    }
}
