using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;


namespace SEP6_Best_Movies_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchlistController : ControllerBase
    {
        private readonly IWatchlistDataService _watchlistDataService;

        public WatchlistController(IWatchlistDataService watchlistDataService)
        {
            _watchlistDataService = watchlistDataService;
        }

        // POST: api/watchlist
        [HttpPost]
        public async Task<IActionResult> CreateWatchlist([FromBody] WatchlistDTO watchlistDTO)
        {
            var createdWatchlist = await _watchlistDataService.CreateWatchlistAsync(watchlistDTO);
            if (createdWatchlist == null)
            {
                return NotFound();
            }


            return Ok(createdWatchlist);
        }

        // GET: api/watchlist/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchlistDTO>> GetWatchlist(int id)
        {
            var watchlist = await _watchlistDataService.GetWatchlistByIdAsync(id);
            if (watchlist == null)
            {
                return NotFound();
            }

            var watchlistDto = new WatchlistDTO
            {
                Id = watchlist.Id,
                Name = watchlist.Name,
                //    Movies = watchlist.Movies,
                UserId = watchlist.UserId
            };

            return Ok(watchlistDto);
        }


        // GET: api/watchlist/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWatchlistsByUserId(string userId)
        {
            var watchlists = await _watchlistDataService.GetWatchlistsByUserIdAsync(userId);
            if (watchlists == null) { return NotFound(); }
            return Ok(watchlists);
        }


        // PUT: api/watchlist
        [HttpPut]
        public async Task<IActionResult> UpdateWatchlist([FromBody] WatchlistDTO watchlistDto)
        {
            var updatedWatchList = await _watchlistDataService.UpdateWatchlistAsync(watchlistDto);

            if (updatedWatchList == null)
            {
                return NotFound();
            }

            return Ok(updatedWatchList);
        }


        // DELETE: api/watchlist/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchlist(int id)
        {
            var watchlist = await _watchlistDataService.GetWatchlistByIdAsync(id);
            if (watchlist == null)
            {
                return NotFound();
            }

            await _watchlistDataService.DeleteWatchlistAsync(id);

            return NoContent();
        }
    }
}
