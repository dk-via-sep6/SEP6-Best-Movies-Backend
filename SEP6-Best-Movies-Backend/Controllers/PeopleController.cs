using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace SEP6_Best_Movies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleDataService _peopleDataService;

        public PeopleController(IPeopleDataService peopleDataService)
        {
            _peopleDataService = peopleDataService;
        }

        //GET: api/people/"personId"
        [HttpGet("{personId}")]
        public async Task<IActionResult> FindByIdAsync(int personId)
        {
            var person = await _peopleDataService.FindByIdAsync(personId);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        //GET: api/people/search/"name"
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchByNameAsync(string name)
        {
            var personInfo = await _peopleDataService.SearchByNameAsync(name);
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
            var personMovieCredit = await _peopleDataService.GetMovieCreditsAsync(personId);
            if (personMovieCredit == null)
            {
                return NotFound();
            }
            return Ok(personMovieCredit);
        }

        //GET: api/people/credits/tv/"personId"
        [HttpGet("credits/tv/{personId}")]
        public async Task<IActionResult> GetTVCreditsAsync(int personId)
        {
            var personTVCredit = await _peopleDataService.GetTVCreditsAsync(personId);
            if (personTVCredit == null)
            {
                return NotFound();
            }
            return Ok(personTVCredit);
        }
    }
}
