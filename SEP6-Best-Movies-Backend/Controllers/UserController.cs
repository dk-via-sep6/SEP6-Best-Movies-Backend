using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;  // Ensure this using statement is added to reference UserDTO

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

            // Here you can add further validation or processing for the user data as needed

            //string response = JsonConvert.SerializeObject(user);

            await Console.Out.WriteLineAsync(user.Username);
            await _userDataService.CreateUser(user);

            // For testing, simply return the received user data
            return Ok(user);
        }
    }
}
