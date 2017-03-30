////namespace Web.Controllers.Finance
////{
////    using System;
////    using System.Web.Http;
////    using Application;
////    using Application.ViewModels.FinanceViewModels;

////    public class CreditExamineController : ApiController
////    {
////        private readonly FinanceAppService financeAppService;

////        /// <summary>
////        /// Initializes a new instance of the <see cref="CreditExamineController" /> class.
////        /// </summary>
////        /// <param name="financeAppService">融资仓储</param>
////        public CreditExamineController(FinanceAppService financeAppService)
////        {
////            this.financeAppService = financeAppService;
////        }

////        /// <summary>
////        /// 通过融资标识获取信审报告ViewModel
////        /// </summary>
////        /// <param name="financeId">融资标识</param>
////        /// <returns>信审ViewModel</returns>
////        [HttpGet]
////        public IHttpActionResult GetCreditExamine(Guid financeId)
////        {
////            var creditExamineViewModel = financeAppService.GetCreditExamineByFinanceId(financeId);

////            if (creditExamineViewModel == null)
////            {
////                return BadRequest();
////            }

////            return Ok(creditExamineViewModel);
////        }

////        /// <summary>
////        /// 编辑信审报告
////        /// </summary>
////        /// <param name="value">信审ViewModel</param>
////        /// <returns>处理结果</returns>
////        [HttpPost]
////        public IHttpActionResult EditCreditExamine(CreditExamineViewModel value)
////        {
////            if (!ModelState.IsValid)
////            {
////                return BadRequest(ValidModel.ShowErrorFirst(ModelState));
////            }

////            financeAppService.EditCreditExamine(value);

////            return Ok();
////        }
////    }
////}