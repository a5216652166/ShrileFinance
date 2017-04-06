using System;
using System.Collections.Generic;
using System.Web.Http;
using Application;
using Models;
using Models.Finance;

namespace Web.Controllers.Finance
{
    public class FinanceController : ApiController
    {
        //private static readonly BLL.Finance.Finance Finance = new BLL.Finance.Finance();
        //private static readonly BLL.Finance.FinanceExtra FinanceExtra = new BLL.Finance.FinanceExtra();
        //private static readonly BLL.Finance.Review Review = new BLL.Finance.Review();
        //private static readonly BLL.Finance.Vehicle Vehicle = new BLL.Finance.Vehicle();
        private readonly FinanceAppService service;

        public FinanceController(FinanceAppService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 获取融资信息
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// qiy 16.03.31
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(Guid financeId)
        {
            var finance = service.Get(financeId);

            return finance != null ? (IHttpActionResult)Ok(finance) : NotFound();
        }

        /// <summary>
        // TODO:
        /// 获取当前授信主体所拥有的产品选项
        /// </summary>
        /// qiy     16.04.07
        /// <returns></returns>
        //[HttpGet]
        //public IHttpActionResult ProducesOption()
        //{
        //    List<ComboInfo> options = Finance.ProducesOptionByCredit();

        //    return options != null ? (IHttpActionResult)Ok(options) : BadRequest("当前角色非授信主体角色");
        //}

        ///// <summary>
        ///// 获取审核信息
        ///// </summary>
        ///// <param name="financeId">融资标识</param>
        ///// yangj   16.08.30
        ///// <returns></returns>
        //[HttpGet]
        //public IHttpActionResult GetReviewInfo(int financeId)
        //{
        //    var result = Review.Get(financeId);

        //    return Ok(result);
        //}

        ///// <summary>
        ///// 获取车辆信息
        ///// </summary>
        ///// <param name="financeId">融资标识</param>
        ///// yangj   16.09.09
        ///// <returns></returns>
        //[HttpGet]
        //public IHttpActionResult GetVehicleInfo(int financeId)
        //{
        //    var result = Vehicle.Get(financeId);

        //    return result != null ? (IHttpActionResult)Ok(result) : NotFound();
        //}
    }
}
