using Microsoft.AspNetCore.Mvc;
using RiverLoggerApi.Models;
using RiverLoggerApi.Services;

namespace RiverLoggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult RegisterUser([FromBody] User user)
        {
            _userService.Create(user);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User user)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
