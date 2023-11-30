using DM.MovieApi.MovieDb.Movies;

namespace ServiceLayer.Interfaces
{
    public interface ITheMovieDbWrapperMovieService
    {
        Task<Movie> FindByIdAsync(int movieId);
        Task<List<MovieInfo>> SearchByTitleAsync(string title);
        Task<Movie> GetLatestAsync();
        Task<List<Movie>> GetNowPlayingAsync();
        Task<List<Movie>> GetUpcomingAsync();
        Task<List<MovieInfo>> GetTopRatedAsync();
        Task<List<MovieInfo>> GetPopularAsync();
        Task<MovieCredit> GetCreditAsync(int movieId);
        Task<List<MovieInfo>> GetRecommendationsAsync(int movieId);
        Task<List<MovieInfo>> GetSimilarAsync(int movieId);
    }
}
