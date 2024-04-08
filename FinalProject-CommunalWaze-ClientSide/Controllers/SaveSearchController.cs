using Bll.Interfaces;
using Dto.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveSearchController : Controller
    {
        readonly ISaveSearchService _service;

        public SaveSearchController(ISaveSearchService service)
        {
            this._service = service;
        }

        [EnableCors]
        [HttpGet]   
        public ActionResult<List<SaveSearchDto>> GetAll()
        {
            return Ok(_service.GetAllSaveSearch());
        }

        [EnableCors]
        [HttpGet("GetByUser/{userId}")]
        public ActionResult<List<SaveSearchDto>> GetAllByUser(int userId)
        {
            return Ok(_service.GetAllSaveSearchByUser(userId));
        }

        [EnableCors]
        [HttpGet("GetByName/{searchId}/{userId}")]
        public ActionResult<SaveSearchDto> GetByName(int searchId, int userId)
        {
            return Ok(_service.GetByName(searchId, userId));
        }

        [EnableCors]
        [HttpPut]
        public ActionResult<ReportDto> Add([FromBody] SaveSearchDto saveSearch)
        {
            return Ok(_service.AddSaveSearch(saveSearch));
        }

        [EnableCors]
        [HttpPost("update/{searchId}/{userId}")]
        public ActionResult<SaveSearchDto> Update(int searchId, [FromBody] SaveSearchDto saveSearch, int userId)
        {
            return Ok(_service.UpdateSaveSearch(searchId, saveSearch, userId));
        }

        [EnableCors]
        [HttpDelete("DeleteSaveSearch/{searchId}")]

        public ActionResult<SaveSearchDto> Delete(int searchId)
        {
            return Ok(_service.DeleteSaveSearch(searchId));
        }
    }
}
