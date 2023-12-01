using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class MovieDataService : IMovieDataService
    {
        private readonly IMapper _mapper;
        private ITheMovieDbWrapperMovieService _movieService;
        public MovieDataService(IMapper mapper, ITheMovieDbWrapperMovieService movieService)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        public async Task<MovieDTO> FindByIdAsync(int id)
        {
            var movieData = await _movieService.FindByIdAsync(id);
            var movie = _mapper.Map<MovieDomain>(movieData);
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task<List<MovieDTO>> SearchByTitleAsync(string title)
        {
            var movieData = await _movieService.SearchByTitleAsync(title);
            var domainObject = _mapper.Map<List<MovieInfoDomain>>(movieData);

            return _mapper.Map<List<MovieDTO>>(domainObject);
        }
        public async Task<MovieDTO> GetLatestAsync()
        {
            var movieData = await _movieService.GetLatestAsync();
            var movie = _mapper.Map<MovieDomain>(movieData);
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task<List<MovieDTO>> GetNowPlayingAsync()
        {
            var movieData = await _movieService.GetNowPlayingAsync();
            var domainObject = _mapper.Map<List<MovieDomain>>(movieData);

            return _mapper.Map<List<MovieDTO>>(domainObject);
        }

        public async Task<List<MovieDTO>> GetUpcomingAsync()
        {
            var movieData = await _movieService.GetUpcomingAsync();
            var domainObject = _mapper.Map<List<MovieDomain>>(movieData);

            return _mapper.Map<List<MovieDTO>>(domainObject);
        }

        public async Task<List<MovieDTO>> GetTopRatedAsync()
        {
            var movieData = await _movieService.GetTopRatedAsync();
            var domainObject = _mapper.Map<List<MovieInfoDomain>>(movieData);

            return _mapper.Map<List<MovieDTO>>(domainObject);
        }

        public async Task<List<MovieDTO>> GetPopularAsync()
        {
            var movieData = await _movieService.GetPopularAsync();
            var domainObject = _mapper.Map<List<MovieInfoDomain>>(movieData);

            return _mapper.Map<List<MovieDTO>>(domainObject);
        }

        public async Task<MovieCreditDomain> GetCreditAsync(int movieId)
        {
            var apiMovieCredit = await _movieService.GetCreditAsync(movieId);
            return MapToDomainMovieCredit(apiMovieCredit);
        }

        public async Task<List<MovieInfoDomain>> GetRecommendationsAsync(int movieId)
        {
            var moviesData = await _movieService.GetRecommendationsAsync(movieId);
            return moviesData.Select(MapToDomainMovieInfo).ToList();
        }

        public async Task<List<MovieInfoDomain>> GetSimilarAsync(int movieId)
        {
            var moviesData = await _movieService.GetSimilarAsync(movieId);
            return moviesData.Select(MapToDomainMovieInfo).ToList();
        }

        private MovieDomain MapToDomainMovie(DM.MovieApi.MovieDb.Movies.Movie movieData)
        {
            return new MovieDomain
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

        private MovieInfoDomain MapToDomainMovieInfo(DM.MovieApi.MovieDb.Movies.MovieInfo movieData)
        {
            return new MovieInfoDomain
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

        private IReadOnlyList<GenreDomain> MapToDomainGenres(IReadOnlyList<DM.MovieApi.MovieDb.Genres.Genre> apiGenres)
        {
            return apiGenres.Select(g => new GenreDomain
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }


        private MovieCreditDomain MapToDomainMovieCredit(DM.MovieApi.MovieDb.Movies.MovieCredit apiMovieCredit)
        {
            var domainMovieCredit = new MovieCreditDomain
            {
                MovieId = apiMovieCredit.MovieId,
                CastMembers = MapCastMembers(apiMovieCredit.CastMembers),
                CrewMembers = MapCrewMembers(apiMovieCredit.CrewMembers)
            };

            return domainMovieCredit;
        }

        private IReadOnlyList<MovieCastMemberDomain> MapCastMembers(IReadOnlyList<DM.MovieApi.MovieDb.Movies.MovieCastMember> apiCastMembers)
        {
            return apiCastMembers.Select(c => new MovieCastMemberDomain
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


        private IReadOnlyList<MovieCrewMemberDomain> MapCrewMembers(IReadOnlyList<DM.MovieApi.MovieDb.Movies.MovieCrewMember> apiCrewMembers)
        {
            return apiCrewMembers.Select(c => new MovieCrewMemberDomain
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
