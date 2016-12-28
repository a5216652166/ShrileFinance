using DataHelper;
using Models;
using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BankCredit
{
   public  class MethodMapper:BankAbstractMapper<MetaInfo>
    {
       /// <summary>
       /// 获取行政区划第一级
       /// </summary>
       /// yand     16.05.25
       /// <returns></returns>
       public DataTable GetProvice()
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT Code,ProvincesOrCity FROM BANK_Administration WHERE Code like '%0000' 
            ");

           return DHelper.ExecuteDataTable(comm);
       }

        public string GetValue(string code)
        {
            string name = string.Empty;
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ProvincesOrCity FROM BANK_Administration WHERE Code =@code
            ");

            DHelper.AddInParameter(comm, "@code", SqlDbType.NVarChar, code);
            DataTable dt = DHelper.ExecuteDataTable(comm);
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["ProvincesOrCity"].ToString();
            }
            return name;
        }

       /// <summary>
       /// 获取行政区划第二级
       /// </summary>
       /// yand     16.05.31
       /// <param name="proviceId">省份ID</param>
       /// <param name="proviceId2">为转换的省份ID</param>
       /// <returns></returns>
       public DataTable GetCity(string proviceId, string proviceId2)
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT Code,ProvincesOrCity FROM BANK_Administration WHERE Code like @proviceId  and  Code!=@proviceId2
            ");

           DHelper.AddInParameter(comm, "@proviceId", SqlDbType.NVarChar, proviceId);
           DHelper.AddInParameter(comm, "@proviceId2", SqlDbType.NVarChar, proviceId2);

           return DHelper.ExecuteDataTable(comm);
       }

       /// <summary>
       /// 查询区域
       /// </summary>
       /// yand 16.05.31
       /// <param name="CityId">转换后城市ID</param>
       /// <param name="cityId2">未转换的城市ID</param>
       /// <returns></returns>
       public DataTable GetArea(string CityId,string cityId2)
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT Code,ProvincesOrCity FROM BANK_Administration WHERE Code like @CityId  and Code !=@cityId2
            ");

           DHelper.AddInParameter(comm, "@CityId", SqlDbType.NVarChar, CityId);
           DHelper.AddInParameter(comm, "@cityId2", SqlDbType.NVarChar, cityId2);

           return DHelper.ExecuteDataTable(comm);
       }

       /// <summary>
       /// 获取行业门类
       /// </summary>
       /// yand     16.05.31
       /// <returns></returns>
       public DataTable GetIndustry()
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT MainID,MainCode,MainName FROM BANK_Industry 
            ");

           return DHelper.ExecuteDataTable(comm);
       }

       /// <summary>
       /// 根据行业ID查询行业标识
       /// </summary>
       /// yand     16.07.06
       /// <returns></returns>
       public DataTable GetIndustryByID(int IndustryID)
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT MainID,MainCode,MainName FROM BANK_Industry  WHERE MainID = @IndustryID
            ");
           DHelper.AddInParameter(comm, "@IndustryId", SqlDbType.Int, IndustryID);
           return DHelper.ExecuteDataTable(comm);
       }
       /// <summary>
       /// 获取行业子类
       /// </summary>
       /// yand     16.05.31
       /// <param name="IndustryId ">门类ID</param>
       /// <returns></returns>
       public DataTable GetChildrenIndustry(int IndustryId)
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ChildrenCode,ChildrenName FROM BANK_IndustryChildren  WHERE MainID =@IndustryId
            ");
           DHelper.AddInParameter(comm, "@IndustryId", SqlDbType.Int, IndustryId);

           return DHelper.ExecuteDataTable(comm);
       }

       /// <summary>
       /// 根据数据元编号加载字典
       /// </summary>
       /// yand     16.07.07
       /// <param name="MetaCode"></param>
       /// <returns></returns>
       public List<ComboInfo> ComboInfoLoad( int MetaCode)
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
               SELECT DISTINCT(bdc.Code),bdc.Name From BANK_DictionaryCode as bdc 
                      LEFT JOIN BANK_DictionaryType AS bdt ON bdt.BDT_ID = bdc.BDT_ID
                      LEFT JOIN BANK_MetaDicRelation AS bmdr ON bmdr.BDT_ID = bdt.BDT_ID
               WHERE bmdr.MetaCode = @MetaCode
            ");
           DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, MetaCode);

           DataTable dt = DHelper.ExecuteDataTable(comm);
           List<ComboInfo> list = new List<ComboInfo>();

           foreach (DataRow dr in dt.Rows)
           {
               ComboInfo cbi = new ComboInfo(dr["Code"].ToString(), dr["Name"].ToString());

               list.Add(cbi);
           }

           return list;
       }
    }
}
