namespace Web.Controllers
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.Loan.LoanViewModels;
    using Core.Entities.Loan;

    public class LoanController : ApiController
    {
        private readonly LoanAppService loanAppService;

        public LoanController(LoanAppService loanAppService)
        {
            this.loanAppService = loanAppService;
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var model = loanAppService.Get(id);

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

            loanAppService.ApplyLoan(model);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(LoanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            loanAppService.ModifyLoan(model);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PaymentPut(PaymentViewModel model)
        {
            loanAppService.Payment(model);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult SearchList(string searchString, int page, int rows, LoanStatusEnum? status = null)
        {
            var models = loanAppService.PagedList(searchString, page, rows, status);

            return Ok(new PagedListViewModel<LoanViewModel>(models));
        }

        [HttpGet]
        public IHttpActionResult CheckLoanNumber(string loanNumber)
        {
            var result = loanAppService.CheckLoanNumber(loanNumber);

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetBalance(Guid id, decimal principle)
        {
            var result = loanAppService.GetBalance(id, principle);

            return Ok(result);
        }
    }
}
