using DomainLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IRatingRepository
    {
        Task<RatingDomain> CreateRatingAsync(RatingDomain rating);
        Task<RatingDomain> GetRatingByIdAsync(int id);
        Task<IEnumerable<RatingDomain>> GetAllRatingsAsync();
        Task<IEnumerable<RatingDomain>> GetRatingsByMovieIdAsync(int movieId);
        Task<IEnumerable<RatingDomain>> GetRatingsByUserIdAsync(string userId);
        Task UpdateRatingAsync(RatingDomain rating);
        Task DeleteRatingAsync(int id);
    }
}
