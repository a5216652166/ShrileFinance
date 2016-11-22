﻿namespace Web.Controllers.Finance
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.FinanceViewModels;
    using Application.ViewModels.ProduceViewModel;

    public class FinanceAuidtController : ApiController
    {
        private readonly FinanceAppService financeAppService;
        private readonly PartnerAppService partnerAppService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceAuidtController" /> class.
        /// </summary>
        /// <param name="financeAppService">融资仓储</param>
        public FinanceAuidtController(FinanceAppService financeAppService ,PartnerAppService partnerAppService)
        {
            this.financeAppService = financeAppService;
            this.partnerAppService = partnerAppService;
        }

        /// <summary>
        /// 通过融资标识获取融资审核ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>融资审核ViewModel</returns>
        [HttpGet]
        public IHttpActionResult GetFinanceAuidt(Guid financeId)
        {
            var financeAuidtViewModel = financeAppService.GetFinanceAuidtByFinanceId(financeId);

            if (financeAuidtViewModel == null)
            {
                return BadRequest();
            }

            return Ok(financeAuidtViewModel);
        }

        /// <summary>
        /// 编辑融资审核
        /// </summary>
        /// <param name="value">融资审核ViewModel</param>
        /// <returns>处理结果</returns>
        [HttpPost]
        public IHttpActionResult EditFinanceAuidt(FinanceAuidtViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ValidModel.ShowErrorFirst(ModelState));
            }

            financeAppService.EditFinanceAuidt(value: value);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetPageList( string Search)
        {
            var list = partnerAppService.GetPageListByPartner(Search);

            return Ok(list);
        }

        public IHttpActionResult Create(FinanceApplyViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ValidModel.ShowErrorFirst(ModelState));
            }

            financeAppService.Create(value);

            return Ok();
        }

        public IHttpActionResult Modify(FinanceApplyViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ValidModel.ShowErrorFirst(ModelState));
            }

            financeAppService.Modify(value);

            return Ok();
        }

        public IHttpActionResult Get(Guid Id)
        {
            var finance = financeAppService.Get(Id);
            return Ok(finance);
        }

        public IHttpActionResult GetParentAndUser()
        {
            var parentAndUser = financeAppService.GetPartnerAndUser();
            return Ok(parentAndUser);
        }

        [HttpGet]
        public IHttpActionResult LeaseeContract(Guid Id)
        {
            string result = financeAppService.CreateLeaseInfoPdf(Id);
            return Ok(result);
        }
    }
}
