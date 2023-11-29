using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SEP6_Best_Movies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieDataService _movieDataService;

        public MoviesController(IMovieDataService movieDataService)
        {
            _movieDataService = movieDataService;
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieDataService.FindMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}
