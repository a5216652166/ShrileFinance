using Models;
using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit
{
    public class Method
    {
        private static readonly DAL.BankCredit.MethodMapper methodMapper = new DAL.BankCredit.MethodMapper();

        //<summary>
        //获取行业分类
        //</summary>
        //yand     16.06.05
        //<returns></returns>
        public List<Dictionary<string, object>> GetIndustry()
        {
            List<Dictionary<string, object>> industryList = new List<Dictionary<string, object>>();

            DataTable dt = new DataTable();
            DataTable dtchildren = new DataTable();

            dt = methodMapper.GetIndustry();//获取门类
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dictionary<string, object> industryChildrenList = new Dictionary<string, object>();
                List<Dictionary<string, string>> industryListChildren = new List<Dictionary<string, string>>();
                dtchildren = methodMapper.GetChildrenIndustry(Convert.ToInt32(dt.Rows[i]["MainID"].ToString()));
                for (int j = 0; j < dtchildren.Rows.Count; j++)
                {
                    Dictionary<string, string> industryChildren = new Dictionary<string, string>();
                    industryChildren.Add("id", dt.Rows[i]["MainCode"].ToString() + dtchildren.Rows[j]["ChildrenCode"].ToString());
                    industryChildren.Add("text", dtchildren.Rows[j]["ChildrenName"].ToString());
                    industryListChildren.Add(industryChildren);
                }
                industryChildrenList.Add("id", dt.Rows[i]["MainCode"].ToString());
                industryChildrenList.Add("text", dt.Rows[i]["MainName"].ToString());
                industryChildrenList.Add("state", "closed");
                industryChildrenList.Add("children", industryListChildren);
                industryList.Add(industryChildrenList);
            }

            return industryList;
        }

        ///// <summary>
        ///// 获取行业分类中的门类
        ///// </summary>
        ///// yand 16.7.06
        ///// <returns></returns>
        //public List<Dictionary<string, string>> GetIndustry()
        //{
        //    List<Dictionary<string, string>> industryList = new List<Dictionary<string, string>>();
        //    DataTable dt = new DataTable();
        //    dt = methodMapper.GetIndustry();//获取门类
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        Dictionary<string, string> industry = new Dictionary<string, string>();
        //        industry.Add("id", dt.Rows[i]["MainID"].ToString());
        //        industry.Add("text", dt.Rows[i]["MainName"].ToString());
        //        industry.Add("children", "");
        //        industry.Add("state", "closed");
        //        industryList.Add(industry);
        //    }

        //    return industryList;
        //}

        /// <summary>
        /// 获取行业子类
        /// </summary>
        /// yand     16.07.06
        /// <param name="IndustryId"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> GetChildrenIndustry(int IndustryId)
        {
            List<Dictionary<string, string>> industryChildrenList = new List<Dictionary<string, string>>();
            DataTable dtChildren = new DataTable();
            DataTable dt = new DataTable();

            dt = methodMapper.GetIndustryByID(IndustryId);//获取行业标识
            if (dt.Rows.Count > 0)
            {
                dtChildren = methodMapper.GetChildrenIndustry(IndustryId);//获取行业子类
                for (int i = 0; i < dtChildren.Rows.Count; i++)
                {
                    Dictionary<string, string> industry = new Dictionary<string, string>();
                    industry.Add("id", dt.Rows[0]["MainCode"] + dtChildren.Rows[i]["ChildrenCode"].ToString());
                    industry.Add("text", dtChildren.Rows[i]["ChildrenName"].ToString());
                    industryChildrenList.Add(industry);
                }
            }
            return industryChildrenList;
        }

        /// <summary>
        /// 根据数据元编号查询字典类型
        /// </summary>
        /// yand     16.07.07
        /// zouql    16.09.20    过滤返回结果
        /// <param name="MetaCode">数据元编号</param>
        /// <returns></returns>
        public List<ComboInfo> ComboInfoLoad(int SegmentRulesID)
        {
            SegmentRulesInfo SegmentRulesInfo = new DAL.BankCredit.SegmentRulesMapper().Find(SegmentRulesID);

            var comboList = methodMapper.ComboInfoLoad(SegmentRulesInfo.MetaCode);

            return FilterComboInfo(comboList, SegmentRulesID);
        }

        /// <summary>
        /// 过滤ComboInfo
        /// </summary>
        /// <param name="comboList">原ComboInfo</param>
        /// <param name="SegmentRulesID">段规则标识</param>
        /// <returns>新ComboInfo</returns>
        private List<ComboInfo> FilterComboInfo(List<ComboInfo> comboList, int SegmentRulesID)
        {
            // 结果容器
            var resultList = new List<ComboInfo>();

            // 段规则标识集合
            var SegmentRulesIDs = new List<int>() { 181, 201, 239, 324, 396 };

            // 判断给定段规则标识是否处于段规则标识集合中
            if (SegmentRulesIDs.Contains(SegmentRulesID))
            {
                if (SegmentRulesID == 181 || SegmentRulesID == 201)
                {
                    // 资产负债表181、利润分配表201
                    var options = new List<int>() { 11, 12, 21, 22, 31, 32, 41, 42, 51, 52, 61, 62, 71, 72 };

                    resultList = FillComboInfo(comboList, options);
                }
                else if (SegmentRulesID == 239)
                {
                    // 现金流量表239
                    var options = new List<int>() { 10, 20, 30, 40, 50, 60, 70 };

                    resultList = FillComboInfo(comboList, options);
                }
                else if (SegmentRulesID == 324)
                {
                    // 事业单位资产负债表324
                    var options = new List<int>() { 11, 12 };

                    resultList = FillComboInfo(comboList, options);
                }
                else
                {
                    // 事业单位收入支出表396
                    var options = new List<int>() { 10 };

                    resultList = FillComboInfo(comboList, options);
                }
            }
            else
            {
                resultList = comboList;
            }

            return resultList;
        }

        /// <summary>
        /// 填充ComboInfo
        /// </summary>
        /// <param name="comboList">原ComboInfo</param>
        /// <param name="options">值数组</param>
        /// <returns>新ComboInfo</returns>
        private List<ComboInfo> FillComboInfo(List<ComboInfo> comboList, List<int> options)
        {
            // 结果容器
            var resultList = new List<ComboInfo>();

            // 容器填充数据
            for (var i = 0; i < comboList.Count; i++)
            {
                if (options.Contains(Convert.ToInt32(comboList[i].value)))
                {
                    resultList.Add(comboList[i]);
                }
            }

            return resultList;
        }


        /// <summary>
        /// 根据段标识和业务类型获取子元素
        /// </summary>
        /// yand    16.07.18
        /// <param name="metaCode">数据元编号</param>
        /// <param name="PanretMetaCode">父级数据元编号</param>
        /// <param name="businessType">字典编码</param>
        /// <returns></returns>
        public List<ComboInfo> ComboLoad(int metaCode, int PanretMetaCode, string businessType)
        {
            DictionaryTypeInfo ParentTypeInfo = new DAL.BankCredit.DictionaryTypeMapper().GetComByMetaCode(PanretMetaCode);
            DictionaryCodeInfo ParentCodeInfo = new DAL.BankCredit.DictionaryCodeMapper().Get(businessType, ParentTypeInfo.DictionaryTypeId);
            DictionaryTypeInfo dictionaryTypeInfo = new DAL.BankCredit.DictionaryTypeMapper().GetComByMetaCode(metaCode);
            return new DAL.BankCredit.DictionaryCodeMapper().GetComListByPanrentCode(ParentCodeInfo.CodeID, dictionaryTypeInfo.DictionaryTypeId);
        }

        /// <summary>
        /// 获取标识变更段中的变更类型的值
        /// </summary>
        /// yand    16.09.30
        /// <param name="metaCode">数据元id</param>
        /// <param name="parentCode">父元素编号</param>
        /// <returns></returns>
        public List<ComboInfo> ChangeType(string metaCode, string parentCode)
        {
            return new DAL.BankCredit.DictionaryCodeMapper().GetChangeType(metaCode, parentCode);
        }

        public string GetParrent(string code)
        {
            string dtfirst = string.Empty;//省
            string dtsecond = string.Empty;//市
            string dtthird = string.Empty;//县（区）
            // 获取区名称
            dtthird = methodMapper.GetValue(code);
            // 获取市名称
            dtsecond = methodMapper.GetValue(code.Substring(0, 4) + "00");
            dtfirst = methodMapper.GetValue(code.Substring(0, 2) + "0000");

            return dtfirst + " " + dtsecond + " " + dtthird;
        }
        /// <summary>
        /// 获取行政区划省级
        /// </summary>
        /// yand     16.05.31
        /// <returns></returns>
        public List<Dictionary<string, object>> GetAdministration()
        {
            List<Dictionary<string, object>> provinceList = new List<Dictionary<string, object>>();
            DataTable dtfirst = new DataTable();//省
            DataTable dtsecond = new DataTable();//市
            DataTable dtthird = new DataTable();//县（区）

            dtfirst = methodMapper.GetProvice();//获取省
            for (int i = 0; i < dtfirst.Rows.Count; i++)
            {
                Dictionary<string, object> province = new Dictionary<string, object>();
                List<Dictionary<string, object>> cityList = new List<Dictionary<string, object>>();
                string proviceId = dtfirst.Rows[i]["Code"].ToString().Substring(0, 2).ToString() + "__00";
                dtsecond = methodMapper.GetCity(proviceId, dtfirst.Rows[i]["Code"].ToString());//获取市
                for (int j = 0; j < dtsecond.Rows.Count; j++)
                {
                    Dictionary<string, object> city = new Dictionary<string, object>();
                    string cityId = dtsecond.Rows[j]["Code"].ToString().Substring(0, 4).ToString() + "__";
                    dtthird = methodMapper.GetArea(cityId, dtsecond.Rows[j]["Code"].ToString());//获取区域
                    List<Dictionary<string, string>> areaList = new List<Dictionary<string, string>>();
                    for (int k = 0; k < dtthird.Rows.Count; k++)
                    {
                        Dictionary<string, string> area = new Dictionary<string, string>();
                        area.Add("id", dtthird.Rows[k]["Code"].ToString());
                        area.Add("text", dtthird.Rows[k]["ProvincesOrCity"].ToString());
                        areaList.Add(area);
                    }
                    city.Add("id", dtsecond.Rows[j]["Code"].ToString());
                    city.Add("text", dtsecond.Rows[j]["ProvincesOrCity"].ToString());
                    city.Add("children", areaList);
                    city.Add("state", "closed");
                    cityList.Add(city);
                }
                province.Add("id", dtfirst.Rows[i]["Code"].ToString());
                province.Add("text", dtfirst.Rows[i]["ProvincesOrCity"].ToString());
                province.Add("state", "closed");
                province.Add("children", cityList);
                provinceList.Add(province);
            }

            return provinceList;
        }




    }
}
