using DataAccessLayer.DbContextFolder;
using DataAccessLayer.Interfaces;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RatingDomain> CreateRatingAsync(RatingDomain rating)
        {
            _context.MovieRatings.Add(rating);
            await _context.SaveChangesAsync();
            return rating;
        }

        public async Task<RatingDomain> GetRatingByIdAsync(int id)
        {
            return await _context.MovieRatings.FindAsync(id);
        }

        public async Task<IEnumerable<RatingDomain>> GetAllRatingsAsync()
        {
            return await _context.MovieRatings.ToListAsync();
        }

        public async Task<IEnumerable<RatingDomain>> GetRatingsByMovieIdAsync(int movieId)
        {
            return await _context.MovieRatings.Where(r => r.MovieId == movieId).ToListAsync();
        }

        public async Task<IEnumerable<RatingDomain>> GetRatingsByUserIdAsync(string userId)
        {
            return await _context.MovieRatings.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task UpdateRatingAsync(RatingDomain rating)
        {
            _context.Entry(rating).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRatingAsync(int id)
        {
            var rating = await _context.MovieRatings.FindAsync(id);
            if (rating != null)
            {
                _context.MovieRatings.Remove(rating);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<RatingDomain> GetRatingByUserAndMovieAsync(string userId, int movieId)
        {
            return await _context.MovieRatings.FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId == movieId);
        }

       
    }
}
