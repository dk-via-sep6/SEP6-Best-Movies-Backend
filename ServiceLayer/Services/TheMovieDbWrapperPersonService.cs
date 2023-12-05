using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.People;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class TheMovieDbWrapperPersonService : ITheMovieDbWrapperPersonService
    {
        private readonly string _bearerToken;

        public TheMovieDbWrapperPersonService(string token)
        {
            _bearerToken = token;
            MovieDbFactory.RegisterSettings(_bearerToken);
        }

        /// <summary>
        /// Gets all the information about a specific Person.
        /// </summary>
        public async Task<Person> FindByIdAsync(int personId)
        {
            var personApi = MovieDbFactory.Create<IApiPeopleRequest>().Value;
            ApiQueryResponse<Person> response = await personApi.FindByIdAsync(personId);

            return response.Item;
        }

        /// <summary>
        /// Searches for People by name.
        /// </summary>
        public async Task<List<PersonInfo>> SearchByNameAsync(string name)
        {
            var personApi = MovieDbFactory.Create<IApiPeopleRequest>().Value;
            ApiSearchResponse<PersonInfo> response = await personApi.SearchByNameAsync(name);

            return response.Results.ToList();
        }

        /// <summary>
        /// Get the movie credits for a specific person id. Includes movie cast and crew information for the person.
        /// </summary>
        public async Task<PersonMovieCredit> GetMovieCreditsAsync(int personId)
        {
            var personApi = MovieDbFactory.Create<IApiPeopleRequest>().Value;
            ApiQueryResponse<PersonMovieCredit> response = await personApi.GetMovieCreditsAsync(personId);

            return response.Item;
        }

        /// <summary>
        /// Get the television credits for a specific person id. Includes TV cast and crew information for the person.
        /// </summary>
        public async Task<PersonTVCredit> GetTVCreditsAsync(int personId)
        {
            var personApi = MovieDbFactory.Create<IApiPeopleRequest>().Value;
            ApiQueryResponse<PersonTVCredit> response = await personApi.GetTVCreditsAsync(personId);

            return response.Item;
        }

    }
}
