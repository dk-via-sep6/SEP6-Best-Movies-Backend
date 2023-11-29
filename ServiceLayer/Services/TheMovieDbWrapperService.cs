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
        }

        public async Task<Movie> FindMovieByIdAsync(int movieId)
        {
            MovieDbFactory.RegisterSettings(_bearerToken);
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

            ApiQueryResponse<Movie> response = await movieApi.FindByIdAsync(movieId);
            await Console.Out.WriteLineAsync(response.Json);
            return response.Item;
        }
    }
}
