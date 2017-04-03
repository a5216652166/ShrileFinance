namespace Web.Controllers.Produce
{
    using System;
    using System.Web.Http;
    using Application.Produce;
    using Application.Produce.ProduceViewModels;
    using Application.ViewModels;

    public class ProduceController : ApiController
    {
        private readonly ProduceAppService service;

        public ProduceController(ProduceAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult PagedList(string searchString, int page, int rows)
        {
            var list = service.PagedList(searchString, page, rows);

            return Ok(new PagedListViewModel<ProduceViewModel>(list));
        }

        [HttpGet]
        public IHttpActionResult Options()
        {
            var options = service.Options();

            return Ok(options);
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var model = service.Get(id);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Post(ProduceBindModel model)
        {
            service.Create(model);

            return Ok(model);
        }

        [HttpPut]
        public IHttpActionResult Put(ProduceBindModel model)
        {
            service.Modify(model);

            return Ok(model);
        }
    }
}