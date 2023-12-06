using DataAccessLayer.DbContextFolder;
using DataAccessLayer.Interfaces;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CommentDomain> CreateCommentAsync(CommentDomain comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<CommentDomain>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<CommentDomain> GetCommentByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<CommentDomain>> GetCommentsByMovieIdAsync(int movieId)
        {
            return await _context.Comments.Where(c => c.MovieId == movieId).ToListAsync();
        }

        public async Task<IEnumerable<CommentDomain>> GetCommentsByUserIdAsync(string userId)
        {
            return await _context.Comments.Where(c => c.AuthorId == userId).ToListAsync();
        }

        public async Task UpdateCommentAsync(CommentDomain comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
