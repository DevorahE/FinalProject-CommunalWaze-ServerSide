using Bll.Interfaces;
using Dto.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsCategoryController : Controller
    {
        readonly IReportsCategoryService _service;
        public ReportsCategoryController(IReportsCategoryService service)
        {
            this._service = service;
        }

        [EnableCors]
        [HttpGet]
        public ActionResult<List<ReportsCategoryDTO>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [EnableCors]
        [HttpPut]
        public ActionResult<ReportsCategoryDTO> Add([FromBody] ReportsCategoryDTO report)
        {
            return Ok(_service.AddCategory(report));
        }
    }
}
