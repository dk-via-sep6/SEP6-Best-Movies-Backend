using DataAccessLayer.Interfaces;
using DomainLayer.Entities;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class CommentDataService : ICommentDataService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentDataService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDomain> CreateCommentAsync(CommentDomain comment)
        {
            return await _commentRepository.CreateCommentAsync(comment);
        }

        public async Task<IEnumerable<CommentDomain>> GetAllCommentsAsync()
        {
            return await _commentRepository.GetAllCommentsAsync();
        }

        public async Task<CommentDomain> GetCommentByIdAsync(int id)
        {
            return await _commentRepository.GetCommentByIdAsync(id);
        }

        public async Task<IEnumerable<CommentDomain>> GetCommentsByMovieIdAsync(int movieId)
        {
            return await _commentRepository.GetCommentsByMovieIdAsync(movieId);
        }

        public async Task<IEnumerable<CommentDomain>> GetCommentsByUserIdAsync(string userId)
        {
            return await _commentRepository.GetCommentsByUserIdAsync(userId);
        }

        public async Task UpdateCommentAsync(CommentDomain comment)
        {
            await _commentRepository.UpdateCommentAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _commentRepository.DeleteCommentAsync(id);
        }
    }
}