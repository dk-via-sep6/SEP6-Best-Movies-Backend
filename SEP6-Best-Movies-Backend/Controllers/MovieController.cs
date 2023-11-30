using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

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

        // GET: api/movies/"id"
        [HttpGet("{movieId}")]
        public async Task<IActionResult> FindByIdAsync(int movieId)
        {

            var movie = await _movieDataService.FindByIdAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        //GET: api/movies/search/
        [HttpGet("search/{title}")]
        public async Task<IActionResult> SearchByIdAsync(string title)
        {
            var movieList = await _movieDataService.SearchByTitleAsync(title);
            if (movieList == null) { return NotFound(); }
            return Ok(movieList);
        }

        // GET: api/movies/latest
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestAsync()
        {
            var movie = await _movieDataService.GetLatestAsync();
            if (movie == null) { return NotFound(); }
            return Ok(movie);
        }

        // GET: api/movies/nowplaying
        [HttpGet("nowplaying")]
        public async Task<IActionResult> GetNowPlayingAsync()
        {
            var movies = await _movieDataService.GetNowPlayingAsync();
            if (movies == null || !movies.Any()) { return NotFound(); }
            return Ok(movies);
        }

        // GET: api/movies/upcoming
        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingAsync()
        {
            var movies = await _movieDataService.GetUpcomingAsync();
            if (movies == null || !movies.Any()) { return NotFound(); }
            return Ok(movies);
        }

        // GET: api/movies/toprated
        [HttpGet("toprated")]
        public async Task<IActionResult> GetTopRatedAsync()
        {
            var movies = await _movieDataService.GetTopRatedAsync();
            if (movies == null || !movies.Any()) { return NotFound(); }
            return Ok(movies);
        }

        // GET: api/movies/popular
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularAsync()
        {
            var movies = await _movieDataService.GetPopularAsync();
            if (movies == null || !movies.Any()) { return NotFound(); }
            return Ok(movies);
        }

        // GET: api/movies/credits/5
        [HttpGet("credits/{id}")]
        public async Task<IActionResult> GetMovieCreditsAsync(int id)
        {
            var credits = await _movieDataService.GetCreditAsync(id);
            if (credits == null) { return NotFound(); }
            return Ok(credits);
        }

        // GET: api/movies/recommendations/5
        [HttpGet("recommendations/{id}")]
        public async Task<IActionResult> GetRecommendationsAsync(int id)
        {
            var recommendations = await _movieDataService.GetRecommendationsAsync(id);
            if (recommendations == null || !recommendations.Any()) { return NotFound(); }
            return Ok(recommendations);
        }

        // GET: api/movies/similar/5
        [HttpGet("similar/{id}")]
        public async Task<IActionResult> GetSimilarMoviesAsync(int id)
        {
            var similarMovies = await _movieDataService.GetSimilarAsync(id);
            if (similarMovies == null || !similarMovies.Any()) { return NotFound(); }
            return Ok(similarMovies);
        }
    }
}
