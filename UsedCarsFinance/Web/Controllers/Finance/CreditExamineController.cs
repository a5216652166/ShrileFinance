﻿namespace Web.Controllers.Finance
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.CreditExamineViewModels;

    public class CreditExamineController : ApiController
    {
        private readonly FinanceAppService financeAppService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditExamineController" /> class.
        /// </summary>
        /// <param name="financeAppService">融资仓储</param>
        public CreditExamineController(FinanceAppService financeAppService)
        {
            this.financeAppService = financeAppService;
        }

        /// <summary>
        /// 通过融资标识获取信审报告ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>信审ViewModel</returns>
        [HttpGet]
        public CreditExamineViewModel Get(Guid financeId)
        {
            var creditExamineViewModel = financeAppService.GetCreditExamineByFinanceId(financeId);

            return creditExamineViewModel;
        }

        /// <summary>
        /// 编辑信审报告
        /// </summary>
        /// <param name="value">信审ViewModel</param>
        [HttpPost]
        public IHttpActionResult Edit(CreditExamineViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ValidModel.ShowErrorFirst(ModelState));
            }

            financeAppService.EditCreditExamine(value);

            return Ok();
        }
    }
}