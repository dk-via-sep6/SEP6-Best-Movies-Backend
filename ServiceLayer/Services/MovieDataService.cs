using DomainLayer.Entities;
using DomainLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class MovieDataService : IMovieDataService
    {
        private ITheMovieDbWrapperMovieService _movieService;
        public MovieDataService(ITheMovieDbWrapperMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<Movie> FindByIdAsync(int id)
        {
            var movieData = await _movieService.FindByIdAsync(id);
            return MapToDomainMovie(movieData);
        }

        public async Task<List<MovieInfo>> SearchByTitleAsync(string title)
        {
            var movieData = await _movieService.SearchByTitleAsync(title);
            return movieData.Select(MapToDomainMovieInfo).ToList();
        }
        public async Task<Movie> GetLatestAsync()
        {
            var movieData = await _movieService.GetLatestAsync();
            return MapToDomainMovie(movieData);
        }

        public async Task<List<Movie>> GetNowPlayingAsync()
        {
            var moviesData = await _movieService.GetNowPlayingAsync();
            return moviesData.Select(MapToDomainMovie).ToList();
        }

        public async Task<List<Movie>> GetUpcomingAsync()
        {
            var moviesData = await _movieService.GetUpcomingAsync();
            return moviesData.Select(MapToDomainMovie).ToList();
        }

        public async Task<List<MovieInfo>> GetTopRatedAsync()
        {
            var moviesData = await _movieService.GetTopRatedAsync();
            return moviesData.Select(MapToDomainMovieInfo).ToList();
        }

        public async Task<List<MovieInfo>> GetPopularAsync()
        {
            var moviesData = await _movieService.GetPopularAsync();
            return moviesData.Select(MapToDomainMovieInfo).ToList();
        }

        public async Task<MovieCredit> GetCreditAsync(int movieId)
        {
            var apiMovieCredit = await _movieService.GetCreditAsync(movieId);
            return MapToDomainMovieCredit(apiMovieCredit);
        }

        public async Task<List<MovieInfo>> GetRecommendationsAsync(int movieId)
        {
            var moviesData = await _movieService.GetRecommendationsAsync(movieId);
            return moviesData.Select(MapToDomainMovieInfo).ToList();
        }

        public async Task<List<MovieInfo>> GetSimilarAsync(int movieId)
        {
            var moviesData = await _movieService.GetSimilarAsync(movieId);
            return moviesData.Select(MapToDomainMovieInfo).ToList();
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
                Genres = MapToDomainGenres(movieData.Genres),
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

        private MovieInfo MapToDomainMovieInfo(DM.MovieApi.MovieDb.Movies.MovieInfo movieData)
        {
            return new MovieInfo
            {
                Id = movieData.Id,
                Title = movieData.Title,
                IsAdultThemed = movieData.IsAdultThemed,
                BackdropPath = movieData.BackdropPath,
                Genres = MapToDomainGenres(movieData.Genres),
                OriginalTitle = movieData.OriginalTitle,
                Overview = movieData.Overview,
                ReleaseDate = movieData.ReleaseDate,
                PosterPath = movieData.PosterPath,
                Popularity = movieData.Popularity,
                Video = movieData.Video,
                VoteAverage = movieData.VoteAverage,
                VoteCount = movieData.VoteCount
            };
        }

        private IReadOnlyList<Genre> MapToDomainGenres(IReadOnlyList<DM.MovieApi.MovieDb.Genres.Genre> apiGenres)
        {
            return apiGenres.Select(g => new Genre
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }


        private MovieCredit MapToDomainMovieCredit(DM.MovieApi.MovieDb.Movies.MovieCredit apiMovieCredit)
        {
            var domainMovieCredit = new MovieCredit
            {
                MovieId = apiMovieCredit.MovieId,
                CastMembers = MapCastMembers(apiMovieCredit.CastMembers),
                CrewMembers = MapCrewMembers(apiMovieCredit.CrewMembers)
            };

            return domainMovieCredit;
        }

        private IReadOnlyList<MovieCastMember> MapCastMembers(IReadOnlyList<DM.MovieApi.MovieDb.Movies.MovieCastMember> apiCastMembers)
        {
            return apiCastMembers.Select(c => new MovieCastMember
            {
                PersonId = c.PersonId,
                CastId = c.CastId,
                CreditId = c.CreditId,
                Character = c.Character,
                Name = c.Name,
                Order = c.Order,
                ProfilePath = c.ProfilePath
            }).ToList();
        }


        private IReadOnlyList<MovieCrewMember> MapCrewMembers(IReadOnlyList<DM.MovieApi.MovieDb.Movies.MovieCrewMember> apiCrewMembers)
        {
            return apiCrewMembers.Select(c => new MovieCrewMember
            {
                PersonId = c.PersonId,
                CreditId = c.CreditId,
                Department = c.Department,
                Job = c.Job,
                Name = c.Name,
                ProfilePath = c.ProfilePath
            }).ToList();
        }
    }
}
