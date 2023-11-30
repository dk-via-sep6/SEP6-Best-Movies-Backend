using DomainLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Interfaces
{
    public interface IMovieDataService
    {
        Task<MovieDTO> FindByIdAsync(int movieId);
        Task<List<MovieInfoDomain>> SearchByTitleAsync(string title);
        Task<MovieDomain> GetLatestAsync();
        Task<List<MovieDomain>> GetNowPlayingAsync();
        Task<List<MovieDomain>> GetUpcomingAsync();
        Task<List<MovieInfoDomain>> GetTopRatedAsync();
        Task<List<MovieInfoDomain>> GetPopularAsync();
        Task<MovieCreditDomain> GetCreditAsync(int movieId);
        Task<List<MovieInfoDomain>> GetRecommendationsAsync(int movieId);
        Task<List<MovieInfoDomain>> GetSimilarAsync(int movieId);
    }
}
