using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;

namespace SEP6_Best_Movies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataService _userDataService;

        public UserController(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest("User data is required");
            }

            await _userDataService.CreateUser(user);
            return Ok(user);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userDataService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserDTO user)
        {
            if (user == null || !id.Equals(user.Id))
            {
                return BadRequest("Invalid user data");
            }

            var existingUser = await _userDataService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userDataService.UpdateUser(user);
            return Ok(user);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userDataService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userDataService.DeleteUser(id);
            return Ok();
        }
    }
}
