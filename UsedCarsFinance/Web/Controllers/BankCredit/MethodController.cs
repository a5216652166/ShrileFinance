using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.BankCredit
{
    public class MethodController : ApiController
    {
        private static readonly BLL.BankCredit.Method _method = new BLL.BankCredit.Method();

        /// <summary>
        /// 获取行业分类
        /// </summary>
        /// yand    16.05.31
        /// <returns></returns>
        [HttpGet]
        public List<Dictionary<string, object>> GetIndustry()
        {
            return _method.GetIndustry();
        }

        /// <summary>
        /// 获取行业分类子类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Dictionary<string, string>> GetChildrenIndustry(int ID)
        {
            return _method.GetChildrenIndustry(ID);
        }

        /// <summary>
        /// 获取行政区划
        /// </summary>
        /// yand    16.05.31
        /// <returns></returns>
        [HttpGet]
        public List<Dictionary<string, object>> GetAdministration()
        {
            return _method.GetAdministration();
        }

        /// <summary>
        /// 获取行政区划父级
        /// </summary>
        /// <returns></returns>
        public string GetParrent(string code)
        {
            return _method.GetParrent(code);
        }

        /// <summary>
        /// 根据数据段规则ID查询字典下拉框
        /// </summary>
        /// yand    16.07.07
        /// <param name="SegmentRulesID">数据段规则ID</param>
        /// <returns></returns>
       [HttpGet]
        public List<ComboInfo> ComboInfoLoad(int SegmentRulesID)
        {
            return _method.ComboInfoLoad(SegmentRulesID);
        }


        /// <summary>
        /// 根据段标识和业务类型获取子元素
        /// </summary>
        /// yand    16.07.18
        /// <param name="metaCode">数据元编号</param>
        /// <param name="PanretMetaCode">父级数据元编号</param>
        /// <param name="businessType">字典编码</param>
        /// <returns></returns>
        [HttpGet]
       public List<ComboInfo> ComboLoad(int MetaCode, int PanretMetaCode, string BusinessType)
       {
           return _method.ComboLoad(MetaCode, PanretMetaCode,BusinessType);
       }

        /// <summary>
        /// 用于获取标识变更段中的值
        /// </summary>
        /// yand  16.09.30
        /// <param name="metaCode">数据元ID</param>
        /// <param name="parentCode">父元素ID</param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> ChangeType(string metaCode, string parentCode)
        {
            return _method.ChangeType(metaCode, parentCode);
        }
    }
}
