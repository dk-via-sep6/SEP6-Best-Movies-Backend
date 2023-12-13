using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class MovieDataService : IMovieDataService
    {
        private readonly IMapper _mapper;
        private readonly ITheMovieDbWrapperMovieService _movieService;
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

            double meanVote = CalculateMeanVote(domainObject);

            int minVoteCount = CalculateMinVoteCount(domainObject);

            var movieDTOs = _mapper.Map<List<MovieDTO>>(domainObject);

            foreach (var movie in movieDTOs)
            {
                movie.WeightedRating = CalculateWeightedRating(movie.VoteCount, movie.VoteAverage, minVoteCount, meanVote);
            }

            return movieDTOs.OrderByDescending(m => m.WeightedRating).ToList();
        }

        private double CalculateWeightedRating(int voteCount, double voteAverage, int minVoteCount, double meanVote)
        {
            return (voteCount / (double)(voteCount + minVoteCount) * voteAverage) + (minVoteCount / (double)(voteCount + minVoteCount) * meanVote);
        }


        private double CalculateMeanVote(List<MovieInfoDomain> movies)
        {
            if (movies == null || movies.Count == 0)
                return 0;

            double totalVotes = 0;
            double totalVoteCount = 0;

            foreach (var movie in movies)
            {
                totalVotes += movie.VoteAverage * movie.VoteCount;
                totalVoteCount += movie.VoteCount;
            }

            return totalVoteCount > 0 ? totalVotes / totalVoteCount : 0;
        }

        private int CalculateMinVoteCount(List<MovieInfoDomain> movies)
        {
            if (movies == null || movies.Count == 0)
                return 0;

            var voteCounts = movies.Select(m => m.VoteCount).OrderByDescending(v => v).ToList();
            int position = (int)(voteCounts.Count * 0.05); // Top 5%
            position = Math.Max(0, Math.Min(position, voteCounts.Count - 1)); // Ensure position is within the list bounds

            return voteCounts[position];
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

        public async Task<MovieCreditDTO> GetCreditAsync(int movieId)
        {
            var apiMovieCredit = await _movieService.GetCreditAsync(movieId);
            var DomainObject = _mapper.Map<MovieCreditDomain>(apiMovieCredit);

            return _mapper.Map<MovieCreditDTO>(DomainObject);
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
    }
}
