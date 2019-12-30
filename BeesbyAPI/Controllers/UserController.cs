using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeesbyAPI.Models;
using BeesbyAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeesbyAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null) return BadRequest();
            return new ObjectResult(_userService.Create(user));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            if (user == null) return BadRequest();
            return new ObjectResult(_userService.Update(id, user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}
