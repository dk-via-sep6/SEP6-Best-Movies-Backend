using DomainLayer.Entities;
using DomainLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class MovieDataService : IMovieDataService
    {
        private ITheMovieDbWrapperService _dbWrapper;
        public MovieDataService(ITheMovieDbWrapperService movieDbWrapper)
        {
            _dbWrapper = movieDbWrapper;
        }

        public async Task<Movie> FindMovieByIdAsync(int id)
        {
            var movieData = await _dbWrapper.FindMovieByIdAsync(id);
            return MapToDomainMovie(movieData);
        }

        private Movie MapToDomainMovie(DM.MovieApi.MovieDb.Movies.Movie movieData)
        {
            return new Movie
            {
                Id = movieData.Id,
                Title = movieData.Title,
                Overview = movieData.Overview,
                ReleaseDate = movieData.ReleaseDate,
                PosterPath = movieData.PosterPath,
                IsAdultThemed = movieData.IsAdultThemed,
                BackdropPath = movieData.BackdropPath,
                MovieCollectionInfo = movieData.MovieCollectionInfo,
                Budget = movieData.Budget,
                Genres = movieData.Genres,
                Homepage = movieData.Homepage,
                ImdbId = movieData.ImdbId,
                OriginalLanguage = movieData.OriginalLanguage,
                OriginalTitle = movieData.OriginalTitle,
                Popularity = movieData.Popularity,
                ProductionCompanies = movieData.ProductionCompanies,
                ProductionCountries = movieData.ProductionCountries,
                Revenue = movieData.Revenue,
                Runtime = movieData.Runtime,
                SpokenLanguages = movieData.SpokenLanguages,
                Status = movieData.Status,
                Tagline = movieData.Tagline,
                IsVideo = movieData.IsVideo,
                VoteAverage = movieData.VoteAverage,
                VoteCount = movieData.VoteCount,
                Keywords = movieData.Keywords
            };
        }
    }
}
