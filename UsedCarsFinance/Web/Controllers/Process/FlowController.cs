using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;

namespace Web.Controllers.Flow
{
    public class FlowController : ApiController
    {
        /// <summary>
        /// 节点选项
        /// </summary>
        /// qiy     16.05.09
        /// <param name="flowId">流程标识</param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> NodeOption(Guid? flowId = null)
        {
            var _node = new BLL.Flow.Node();

            return _node.Option(flowId);
        }
    }
}
