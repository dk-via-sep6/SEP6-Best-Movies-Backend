using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace SEP6_Best_Movies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonDataService _personDataService;

        public PersonController(IPersonDataService personDataService)
        {
            _personDataService = personDataService;
        }

        //GET: api/people/"personId"
        [HttpGet("{personId}")]
        public async Task<IActionResult> FindByIdAsync(int personId)
        {
            var person = await _personDataService.FindByIdAsync(personId);
            if (person == null)
            {
                return NotFound();
            }
            await Console.Out.WriteLineAsync("PersonContoller --> Found Person by ID: " + person.Id);
            return Ok(person);
        }

        //GET: api/people/search/"name"
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchByNameAsync(string name)
        {
            var personInfo = await _personDataService.SearchByNameAsync(name);
            if (personInfo == null)
            {
                return NotFound();
            }
            return Ok(personInfo);
        }

        //GET: api/people/credits/movie/"personId"
        [HttpGet("credits/movie/{personId}")]
        public async Task<IActionResult> GetMovieCreditsAsync(int personId)
        {
            var personMovieCredit = await _personDataService.GetMovieCreditsAsync(personId);
            if (personMovieCredit == null)
            {
                return NotFound();
            }
            await Console.Out.WriteLineAsync("PersonContoller --> Found Person Movie Credits by ID: " + personId);
            return Ok(personMovieCredit);
        }

        //GET: api/people/credits/tv/"personId"
        [HttpGet("credits/tv/{personId}")]
        public async Task<IActionResult> GetTVCreditsAsync(int personId)
        {
            var personTVCredit = await _personDataService.GetTVCreditsAsync(personId);
            if (personTVCredit == null)
            {
                return NotFound();
            }
            return Ok(personTVCredit);
        }
    }
}
