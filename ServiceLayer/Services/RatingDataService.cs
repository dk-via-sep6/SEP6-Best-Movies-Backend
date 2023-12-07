using DataAccessLayer.Interfaces;
using ServiceLayer.Interfaces;
using DomainLayer.Entities;
namespace ServiceLayer.Services
{
    public class RatingDataService : IRatingDataService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingDataService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<RatingDomain> CreateRatingAsync(RatingDomain rating)
        {
            return await _ratingRepository.CreateRatingAsync(rating);
        }

        public async Task<RatingDomain> GetRatingByIdAsync(int id)
        {
            return await _ratingRepository.GetRatingByIdAsync(id);
        }

        public async Task<IEnumerable<RatingDomain>> GetAllRatingsAsync()
        {
            return await _ratingRepository.GetAllRatingsAsync();
        }

        public async Task<IEnumerable<RatingDomain>> GetRatingsByMovieIdAsync(int movieId)
        {
            return await _ratingRepository.GetRatingsByMovieIdAsync(movieId);
        }

        public async Task<IEnumerable<RatingDomain>> GetRatingsByUserIdAsync(string userId)
        {
            return await _ratingRepository.GetRatingsByUserIdAsync(userId);
        }

        public async Task UpdateRatingAsync(RatingDomain rating)
        {
            await _ratingRepository.UpdateRatingAsync(rating);
        }

        public async Task DeleteRatingAsync(int id)
        {
            await _ratingRepository.DeleteRatingAsync(id);
        }
        public async Task<RatingDomain> GetRatingByUserAndMovieAsync(string userId, int movieId)
        {
            return await _ratingRepository.GetRatingByUserAndMovieAsync(userId, movieId);
        }

    }
}
