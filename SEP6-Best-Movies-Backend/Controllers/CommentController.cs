using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using DomainLayer.Entities;
// ... other necessary using directives

namespace SEP6_Best_Movies_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentDataService _commentDataService;

        public CommentController(ICommentDataService commentDataService)
        {
            _commentDataService = commentDataService;
        }

        // POST: api/comments
        [HttpPost]
        public async Task<ActionResult<CommentDTO>> CreateComment([FromBody] CommentDTO commentDto)
        {
            var comment = new CommentDomain
            {
                // Map properties from commentDto to CommentDomain
                AuthorId = commentDto.AuthorId,
                MovieId = commentDto.MovieId,
                Timestamp = commentDto.Timestamp,
                Content = commentDto.Content,
                LikedBy=commentDto.LikedBy,
                AuthorUsername = commentDto.AuthorUsername
            };
            var createdComment = await _commentDataService.CreateCommentAsync(comment);

            var createdCommentDto = new CommentDTO
            {
                // Map properties from CommentDomain to CommentDTO
                Id = createdComment.Id,
                AuthorId = createdComment.AuthorId,
                MovieId = createdComment.MovieId,
                Timestamp = createdComment.Timestamp,
                Content = createdComment.Content,
                LikedBy=createdComment.LikedBy,
                AuthorUsername = createdComment.AuthorUsername

            };
            return CreatedAtAction(nameof(GetComment), new { id = createdComment.Id }, createdCommentDto);
        }

        // GET: api/comments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> GetComment(int id)
        {
            var comment = await _commentDataService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            var commentDto = new CommentDTO
            {
                // Map properties from CommentDomain to CommentDTO
                Id = comment.Id,
                AuthorId = comment.AuthorId,
                MovieId = comment.MovieId,
                Timestamp = comment.Timestamp,
                Content = comment.Content,
                LikedBy=comment.LikedBy,
                AuthorUsername=comment.AuthorUsername,
            };
            return Ok(commentDto);
        }

        // GET: api/comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllComments()
        {
            var comments = await _commentDataService.GetAllCommentsAsync();
            var commentDtos = comments.Select(c => new CommentDTO
            {
                // Map each CommentDomain to CommentDTO
                Id = c.Id,
                AuthorId = c.AuthorId,
                MovieId = c.MovieId,
                Timestamp = c.Timestamp,
                Content = c.Content,
                LikedBy=c.LikedBy,
                AuthorUsername=c.AuthorUsername,
            }).ToList();

            return Ok(commentDtos);
        }

        // GET: api/comments/movie/{movieId}
        [HttpGet("movie/{movieId}")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetCommentsByMovieId(int movieId)
        {
            var comments = await _commentDataService.GetCommentsByMovieIdAsync(movieId);
            var commentDtos = comments.Select(c => new CommentDTO
            {
                // Map each CommentDomain to CommentDTO
                Id = c.Id,
                AuthorId = c.AuthorId,
                MovieId = c.MovieId,
                Timestamp = c.Timestamp,
                Content = c.Content,
                LikedBy = c.LikedBy,
                AuthorUsername = c.AuthorUsername
            }).ToList();

            return Ok(commentDtos);
        }

        // PUT: api/comments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentDTO commentDto)
        {
            var commentToUpdate = await _commentDataService.GetCommentByIdAsync(id);
            if (commentToUpdate == null)
            {
                return NotFound();
            }

            // Map properties from CommentDTO to CommentDomain
            commentToUpdate.AuthorId = commentDto.AuthorId;
            commentToUpdate.MovieId = commentDto.MovieId;
            commentToUpdate.Timestamp = commentDto.Timestamp;
            commentToUpdate.Content = commentDto.Content;
            commentToUpdate.LikedBy=commentDto.LikedBy;
            commentToUpdate.AuthorUsername = commentDto.AuthorUsername;
            await _commentDataService.UpdateCommentAsync(commentToUpdate);
            return NoContent();
        }

        [HttpPut("{id}/like")]
        public async Task<IActionResult> LikeComment(int id, [FromBody] string userId)
        {
            var comment = await _commentDataService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            if (!comment.LikedBy.Contains(userId))
            {
                comment.LikedBy.Add(userId);
                await _commentDataService.UpdateCommentAsync(comment);
            }

            return NoContent();
        }

        // PUT: api/comments/{id}/unlike
        [HttpPut("{id}/unlike")]
        public async Task<IActionResult> UnlikeComment(int id, [FromBody] string userId)
        {
            var comment = await _commentDataService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            if (comment.LikedBy.Contains(userId))
            {
                comment.LikedBy.Remove(userId);
                await _commentDataService.UpdateCommentAsync(comment);
            }

            return NoContent();
        }
        // DELETE: api/comments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentDataService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _commentDataService.DeleteCommentAsync(id);
            return NoContent();
        }

    }

}
