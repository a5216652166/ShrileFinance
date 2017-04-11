namespace Web.Controllers.Finance.BranchOffice
{
    using System;
    using System.Web.Http;
    using Application.AppServices.FinanceAppServices.BranchOfficeAppServices;
    using Application.ViewModels;
    using Application.ViewModels.FinanceViewModels.BranchOfficeViewModels;

    public class BranchOfficeController : ApiController
    {
        private readonly BranchOfficeAppService branchOfficeAppService;

        public BranchOfficeController(BranchOfficeAppService branchOfficeAppService)
        {
            this.branchOfficeAppService = branchOfficeAppService;
        }

        [HttpGet]
        public IHttpActionResult PageList(string searchString, int page, int rows)
        {
            var list = branchOfficeAppService.PageList(searchString ?? string.Empty, page, rows);

            return Ok(new PagedListViewModel<BranchOfficeViewModel>(list));
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var model = branchOfficeAppService.Get(id);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(BranchOfficeViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            branchOfficeAppService.Create(model);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Modify(BranchOfficeViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            branchOfficeAppService.Modify(model);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Option()
        {
            var option = branchOfficeAppService.GetOption();

            return Ok(option);
        }
    }
}
