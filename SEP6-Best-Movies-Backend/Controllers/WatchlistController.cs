using DomainLayer.Entities;
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
        public async Task<ActionResult<WatchlistDTO>> CreateWatchlist([FromBody] WatchlistDTO watchlistDto)
        {
            var watchlistDomain = new WatchlistDomain
            {
                Name = watchlistDto.Name,
                Movies = watchlistDto.Movies,
                UserId = watchlistDto.UserId
            };

            var createdWatchlist = await _watchlistDataService.CreateWatchlistAsync(watchlistDomain);

            var createdWatchlistDto = new WatchlistDTO
            {
                Id = createdWatchlist.Id,
                Name = createdWatchlist.Name,
                Movies = createdWatchlist.Movies,
                UserId = createdWatchlist.UserId
            };

            return CreatedAtAction(nameof(GetWatchlist), new { id = createdWatchlist.Id }, createdWatchlistDto);
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
                Movies = watchlist.Movies,
                UserId = watchlist.UserId
            };

            return Ok(watchlistDto);
        }


        // GET: api/watchlist/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<WatchlistDTO>>> GetWatchlistsByUserId(string userId)
        {
            var watchlists = await _watchlistDataService.GetWatchlistsByUserIdAsync(userId);

            var watchlistDtos = watchlists.Select(wl => new WatchlistDTO
            {
                Id = wl.Id,
                Name = wl.Name,
                Movies = wl.Movies,
                UserId = wl.UserId
            }).ToList();

            return Ok(watchlistDtos);
        }


        // PUT: api/watchlist/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWatchlist(int id, [FromBody] WatchlistDTO watchlistDto)
        {
            var watchlistToUpdate = await _watchlistDataService.GetWatchlistByIdAsync(id);
            if (watchlistToUpdate == null)
            {
                return NotFound();
            }

            watchlistToUpdate.Name = watchlistDto.Name;
            watchlistToUpdate.Movies = watchlistDto.Movies;
            // UserId is typically not updated, but if needed, can be set here

            await _watchlistDataService.UpdateWatchlistAsync(watchlistToUpdate);

            return NoContent();
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
        // Call service to delete watchlist and return the result
    }

    // Additional methods can be added as needed
}
