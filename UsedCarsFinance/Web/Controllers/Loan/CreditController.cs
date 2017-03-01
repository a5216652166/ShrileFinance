namespace Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.PartnerViewModels;

    public class CreditController : ApiController
    {
        private readonly PartnerAppService service;

        public CreditController(PartnerAppService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 获取渠道主体信息
        /// </summary>
        /// <param name="creditId">授信标识</param>
        /// qiy     16.03.29
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(Guid creditId)
        {
            var partner = service.Get(creditId);

            return partner != null ? (IHttpActionResult)Ok(partner) : NotFound();
        }

        /// <summary>
        /// 渠道列表
        /// </summary>
        /// qiy     16.03.29
        /// <param name="page">页码</param>
        /// <param name="rows">尺寸</param>
        /// <param name="searchString">搜索字符串</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAll(int page, int rows, string searchString = null)
        {
            var list = service.List(searchString, page, rows);

            return Ok(new PagedListViewModel<PartnerViewModel>(list));
        }

        /// <summary>
        /// 添加渠道主体
        /// </summary>
        /// qiy     16.03.29
        /// <param name="model">值</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(PartnerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.Create(model);

            return Ok();
        }

        /// <summary>
        /// 修改渠道主体
        /// </summary>
        /// qiy     16.03.29
        /// <param name="model">值</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> Put(PartnerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.ModifyAsync(model);

            return Ok();
        }
    }
}