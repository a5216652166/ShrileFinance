namespace Web.Controllers.Loan
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.Loan.LoanViewModels;
    using Core.Entities.Loan;

    public class LoanController : ApiController
    {
        private readonly LoanAppService service;

        public LoanController(LoanAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var model = service.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Post(LoanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.ApplyLoan(model);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(LoanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.ModifyLoan(model);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PaymentPut(PaymentViewModel model)
        {
            service.Payment(model);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult SearchList(string searchString, int page, int rows, LoanStatusEnum? status = null)
        {
            var models = service.PagedList(searchString, page, rows, status);

            return Ok(new PagedListViewModel<LoanViewModel>(models));
        }

        [HttpGet]
        public IHttpActionResult CheckLoanNumber(string loanNumber)
        {
            var result = service.CheckLoanNumber(loanNumber);

            return Ok(result);
        }
    }
}
