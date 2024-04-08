using Bll.Interfaces;
using Dto.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _service;
        public UserController(IUserService service)
        {
            this._service = service;
        }

        // GET: api/<ValuesController>
        [EnableCors]
        [HttpGet]
        public ActionResult<List<UserDto> > GetAll() 
        {
            return Ok(_service.GetAll());
        }
        [EnableCors]
        [HttpGet("ExistEmail/{eMail}")]
        public ActionResult<bool> ExistEmail(string eMail)
        {
            return Ok(_service.EmailExist(eMail));
        }

        [EnableCors]
        [HttpGet("getById/{eMail}/{password}")]
        public ActionResult<UserDto> GetById(string eMail, string password)
        {
            return Ok(_service.GetById(eMail, password));
        }

        [EnableCors]
        [HttpPut("add")]
        public ActionResult<UserDto> Add([FromBody] UserDto user) 
        {
            return Ok(_service.Add(user));  
        }

        [EnableCors]
        [HttpPost("update/{eMail}")]
        public ActionResult<UserDto> Update(String eMail, [FromBody] UserDto user)
        {
            return Ok(_service.Update(eMail, user));
        }

        [EnableCors]
        [HttpPost("update/{eMail}/{password}")]
        public ActionResult<UserDto> UpdatePassword(String eMail, String password)
        {
            return Ok(_service.UpdatePassword(eMail, password));
        }

    }
}
