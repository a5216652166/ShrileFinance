namespace Web.Controllers.Produce
{
    ////using System;
    ////using System.Collections.Generic;
    ////using System.Web.Http;
    ////using Application;
    ////using Application.ViewModels;
    ////using Application.ViewModels.ProduceViewModel;

    ////public class ProduceController : ApiController
    ////{
    ////    private readonly ProduceAppService produceAppService;

    ////    public ProduceController(ProduceAppService produceAppService)
    ////    {
    ////        this.produceAppService = produceAppService;
    ////    }

    ////   [HttpGet]
    ////    public IHttpActionResult Get(Guid id)
    ////    {
    ////         var produce = produceAppService.Get(id);

    ////        return Ok(produce);
    ////    }

    ////    public IHttpActionResult GetAll()
    ////    {
    ////        var produce = produceAppService.GetAll();

    ////        return Ok(produce);
    ////    }

    ////    public IHttpActionResult GetByCode(string code)
    ////    {
    ////        var proudce = produceAppService.GetByCode(code);

    ////        return Ok(proudce);
    ////    }

    ////    public IHttpActionResult Create(ProduceViewModel value)
    ////    {
    ////        produceAppService.Create(value);

    ////        return Ok();
    ////    }

    ////    public IHttpActionResult Modify(ProduceViewModel value)
    ////    {
    ////        produceAppService.Modify(value);

    ////        return Ok();
    ////    }

    ////    [HttpGet]
    ////    public IHttpActionResult GetPageList(int page, int rows, string Search)
    ////    {
    ////        var list = produceAppService.GetPageList(Search, page, rows);

    ////        return Ok(new PagedListViewModel<ProduceListViewModel>(list));
    ////    }
    ////}
}