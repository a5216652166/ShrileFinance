namespace Web.Controllers.Flow
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.ProcessViewModels;
    using Core.Exceptions;

    public class InstanceController : ApiController
    {
        private static readonly BLL.Flow.Instance Instance = new BLL.Flow.Instance();
        private readonly ProcessAppService service;

        public InstanceController(ProcessAppService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 待办列表
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="rows">行数</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult DoingList(int page, int rows, string searchString = null, Guid? currentNode = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var list = service.DoingPagedList(searchString, page, rows, currentNode, beginTime, endTime);

            return Ok(new PagedListViewModel<InstanceViewModel>(list));
        }

        /// <summary>
        /// 已办列表
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="rows">行数</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult DoneList(int page, int rows, string searchString = null, Guid? currentNode = null, DateTime? beginTime = null, DateTime? endTime = null, Core.Entities.Flow.InstanceStatusEnum? status = null)
        {
            var list = service.DonePagedList(searchString, page, rows, currentNode, beginTime, endTime, status);

            return Ok(new PagedListViewModel<InstanceViewModel>(list));
        }

        /// <summary>
        /// 添加待发起流程
        /// </summary>
        /// <param name="processType">流程类型</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult StartProcess(ProcessPostedViewModel.ProcessTypeEnum? processType)
        {
            var instanceId = service.StartNew(processType);

            return Ok(instanceId);
        }

        /// <summary>
        /// 流程流转
        /// </summary>
        /// <param name="model">视图模型</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Transfer(ProcessPostedViewModel model)
        {
            try
            {
                service.Process(model);

                return Ok();
            }
            catch (InvalidOperationAppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 流程撤回
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Revoke(Guid instanceId)
        {
            try
            {
                service.Withdraw(instanceId);

                return Ok();
            }
            catch (InvalidOperationAppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 获取框架页
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFrame(Guid instanceId)
        {
            var frame = service.GetFrame(instanceId);

            return Ok(frame);
        }

        /// <summary>
        /// 获取查看框架页
        /// </summary>
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFrameView(Guid instanceId)
        {
            var frame = service.GetFrame(instanceId, true);

            return Ok(frame);
        }

        /// <summary>
        /// 流程作废处理
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        [HttpGet]
        public  IHttpActionResult ProcessAbolish(Guid instanceId)
        {
            try
            {
                service.ProcessAbolish(instanceId);

                return Ok();
            }
            catch (InvalidOperationAppException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
