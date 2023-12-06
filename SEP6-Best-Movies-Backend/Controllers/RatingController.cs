using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
// ... other necessary using directives

[ApiController]
[Route("api/[controller]")]
public class RatingsController : ControllerBase
{
    private readonly IRatingDataService _ratingDataService;

    public RatingsController(IRatingDataService ratingDataService)
    {
        _ratingDataService = ratingDataService;
    }

    // POST: api/ratings
    [HttpPost]
    public async Task<ActionResult<RatingDTO>> CreateRating([FromBody] RatingDTO ratingDto)
    {
        var rating = new RatingDomain
        {
            UserId = ratingDto.UserId,
            MovieId = ratingDto.MovieId,
            Rating = ratingDto.Rating
        };
        var createdRating = await _ratingDataService.CreateRatingAsync(rating);

        var createdRatingDto = new RatingDTO
        {
            Id = createdRating.Id,
            UserId = createdRating.UserId,
            MovieId = createdRating.MovieId,
            Rating = createdRating.Rating
        };
        return CreatedAtAction(nameof(GetRating), new { id = createdRating.Id }, createdRatingDto);
    }

    // GET: api/ratings/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<RatingDTO>> GetRating(int id)
    {
        var rating = await _ratingDataService.GetRatingByIdAsync(id);
        if (rating == null)
        {
            return NotFound();
        }
        var ratingDto = new RatingDTO
        {
            Id = rating.Id,
            UserId = rating.UserId,
            MovieId = rating.MovieId,
            Rating = rating.Rating
        };
        return Ok(ratingDto);
    }

    // ... Implement other CRUD operations

    // Example for GET: api/ratings/movie/{movieId}
    [HttpGet("movie/{movieId}")]
    public async Task<ActionResult<IEnumerable<RatingDTO>>> GetRatingsByMovieId(int movieId)
    {
        var ratings = await _ratingDataService.GetRatingsByMovieIdAsync(movieId);
        var ratingDtos = ratings.Select(r => new RatingDTO
        {
            Id = r.Id,
            UserId = r.UserId,
            MovieId = r.MovieId,
            Rating = r.Rating
        }).ToList();

        return Ok(ratingDtos);
    }

    // ... Similar methods for Update and Delete
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRating(int id, [FromBody] RatingDTO ratingDto)
    {
        var ratingToUpdate = await _ratingDataService.GetRatingByIdAsync(id);
        if (ratingToUpdate == null)
        {
            return NotFound();
        }

        ratingToUpdate.UserId = ratingDto.UserId; // Depending on your design, you might not allow updating UserId
        ratingToUpdate.MovieId = ratingDto.MovieId;
        ratingToUpdate.Rating = ratingDto.Rating;

        await _ratingDataService.UpdateRatingAsync(ratingToUpdate);
        return NoContent();
    }

    // DELETE: api/ratings/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRating(int id)
    {
        var rating = await _ratingDataService.GetRatingByIdAsync(id);
        if (rating == null)
        {
            return NotFound();
        }

        await _ratingDataService.DeleteRatingAsync(id);
        return NoContent();
    }

    // GET: api/ratings/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<RatingDTO>>> GetRatingsByUserId(string userId)
    {
        var ratings = await _ratingDataService.GetRatingsByUserIdAsync(userId);
        var ratingDtos = ratings.Select(r => new RatingDTO
        {
            Id = r.Id,
            UserId = r.UserId,
            MovieId = r.MovieId,
            Rating = r.Rating
        }).ToList();

        return Ok(ratingDtos);
    }
}
