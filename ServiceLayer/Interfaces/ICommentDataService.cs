using DomainLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface ICommentDataService
    {
        Task<CommentDomain> CreateCommentAsync(CommentDomain comment);
        Task<IEnumerable<CommentDomain>> GetAllCommentsAsync();
        Task<CommentDomain> GetCommentByIdAsync(int id);
        Task<IEnumerable<CommentDomain>> GetCommentsByMovieIdAsync(int movieId);
        Task<IEnumerable<CommentDomain>> GetCommentsByUserIdAsync(string userId);
        Task UpdateCommentAsync(CommentDomain comment);
        Task DeleteCommentAsync(int id);
    }
}
