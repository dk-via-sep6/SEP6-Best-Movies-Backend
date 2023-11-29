using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using DomainLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class TheMovieDbWrapperService : ITheMovieDbWrapperService
    {
        private readonly string _bearerToken;

        public TheMovieDbWrapperService(string token)
        {
            _bearerToken = token;
            MovieDbFactory.RegisterSettings(_bearerToken);
        }

        /// <summary>
        /// Gets all the information about a specific Movie.
        /// </summary>
        public async Task<Movie> FindByIdAsync(int movieId)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiQueryResponse<Movie> response = await movieApi.FindByIdAsync(movieId);

            return response.Item;
        }

        /// <summary>
        /// Searches for Movies by title.
        /// </summary>
        public async Task<List<MovieInfo>> SearchByTitleAsync(string title)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(title);

            return response.Results.ToList();
        }

        /// <summary>
        /// Gets the most recent movie that has been added to TheMovieDb.org.
        /// </summary>
        public async Task<Movie> GetLatestAsync()
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiQueryResponse<Movie> response = await movieApi.GetLatestAsync();

            return response.Item;
        }

        /// <summary>
        /// Gets the list of movies playing that have been, or are being released this week.
        /// </summary>
        public async Task<List<Movie>> GetNowPlayingAsync()
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<Movie> response = await movieApi.GetNowPlayingAsync();

            return response.Results.ToList();
        }

        /// <summary>
        /// Gets the list of upcoming movies by release date.
        /// </summary>
        public async Task<List<Movie>> GetUpcomingAsync()
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<Movie> response = await movieApi.GetUpcomingAsync();

            return response.Results.ToList();
        }

        /// <summary>
        /// Gets the list of top rated movies which is refreshed daily.
        /// </summary>
        public async Task<List<MovieInfo>> GetTopRatedAsync()
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.GetTopRatedAsync();

            return response.Results.ToList();
        }

        /// <summary>
        /// Gets the list of popular movies which is refreshed daily.
        /// </summary>
        public async Task<List<MovieInfo>> GetPopularAsync()
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.GetPopularAsync();

            return response.Results.ToList();
        }

        /// <summary>
        /// Get the cast and crew information for a specific movie id.
        /// </summary>
        public async Task<MovieCredit> GetCreditAsync(int movieId)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiQueryResponse<MovieCredit> response = await movieApi.GetCreditsAsync(movieId);

            return response.Item;
        }

        /// <summary>
        /// Get a list of recommended movies for a movie.
        /// </summary>  
        public async Task<List<MovieInfo>> GetRecommendationsAsync(int movieId)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.GetRecommendationsAsync(movieId);

            return response.Results.ToList();
        }

        /// <summary>
        /// Get a list of similar movies. This is not the same as the "Recommendation" system you see on the website.
        /// These items are assembled by looking at keywords and genres.
        ///</summary>
        public async Task<List<MovieInfo>> GetSimilarAsync(int movieId)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.GetSimilarAsync(movieId);

            return response.Results.ToList();
        }
    }
}
