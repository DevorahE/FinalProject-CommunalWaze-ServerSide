using Bll.Interfaces;
using Dto.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        readonly IReportService _service;
        public ReportController(IReportService service)
        {
            this._service = service;
        }

        [EnableCors]
        [HttpGet]
        public ActionResult<List<ReportDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [EnableCors]
        [HttpGet ("GetReportByCode/{codeReport}")]
        public ActionResult<ReportDto> GetReportByCode(int codeReport)
        {
            return Ok(_service.GetReportByCode(codeReport));
        }

        [EnableCors]
        [HttpGet("GetReportsByUser/{user}")]
        public ActionResult<List<ReportDto>> GetReportsByUser(int user)
        {
            return Ok(_service.GetReportsByUser(user));
        }

        [HttpGet("GetReportsByColor/{color}")]
        public ActionResult<List<ReportDto>> GetReportsByColor(int color)
        {
            return Ok(_service.GetReportsByColor(color));
        }

        [EnableCors]
        [HttpPut]
        public ActionResult<ReportDto> Add([FromBody] ReportDto report)
        {
            return Ok(_service.AddReport(report));
        }

        [EnableCors]
        [HttpDelete("DeleteReport/{codeReport}")]
        public ActionResult<ReportDto> Delete(int codeReport)
        {
            return Ok(_service.DeleteReport(codeReport));
        }

        [EnableCors]
        [HttpPost("update/{codeReport}")]
        public ActionResult<ReportDto> Update(int codeReport, [FromBody] ReportDto report)
        {
            return Ok(_service.UpdateReport(codeReport, report));
        }

    }
}
