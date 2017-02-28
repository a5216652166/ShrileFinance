using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models.Finance;
using Models.Flow;
using System.Reflection;
using BLL.Finance;

namespace Web.Controllers.Flow
{
    public class FinanceScriptController : ApiController
    {
        private static readonly BLL.Flow.Engine _engine = new BLL.Flow.Engine();

        /// <summary>
        /// 通用保存方法
        /// </summary>
        /// wangpf  16.08.30
        /// yaoy    16.09.08
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SaveData(FlowData data)
        {
            return _engine.Transfer(data) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        /// <summary>
        /// 流程流转
        /// </summary>
        /// yaoy    16.09.08
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Transfer(FlowData value)
        {
            return _engine.Transfer(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }
    }
}
