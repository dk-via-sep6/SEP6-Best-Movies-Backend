using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;
using System.Threading.Tasks;

namespace SEP6_Best_Movies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] ExpandoObject user)
        {
            if(user == null)
            {
                return BadRequest("bad ");
            }
            string response= JsonConvert.SerializeObject(user);
            await Console.Out.WriteLineAsync(response);

            return Ok(user); 
            // For testing, simply return the received user data
            
        }
    }
}
