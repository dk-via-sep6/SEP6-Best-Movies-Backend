using DomainLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Interfaces
{
    public interface IMovieDataService
    {
        Task<MovieDTO> FindByIdAsync(int movieId);
        Task<List<MovieDTO>> SearchByTitleAsync(string title);
        Task<MovieDTO> GetLatestAsync();
        Task<List<MovieDTO>> GetNowPlayingAsync();
        Task<List<MovieDTO>> GetUpcomingAsync();
        Task<List<MovieDTO>> GetTopRatedAsync();
        Task<List<MovieDTO>> GetPopularAsync();
        Task<MovieCreditDomain> GetCreditAsync(int movieId);
        Task<List<MovieInfoDomain>> GetRecommendationsAsync(int movieId);
        Task<List<MovieInfoDomain>> GetSimilarAsync(int movieId);
    }
}
