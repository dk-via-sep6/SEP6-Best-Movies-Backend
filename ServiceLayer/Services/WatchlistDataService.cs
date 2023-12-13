using DataAccessLayer.Interfaces;
using DomainLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class WatchlistDataService : IWatchlistDataService
    {
        private readonly IWatchlistRepository _watchlistRepository;
        private readonly IMovieDataService _movieDataService;

        public WatchlistDataService(IWatchlistRepository watchlistRepository, IMovieDataService movieDataService)
        {
            _watchlistRepository = watchlistRepository;
            _movieDataService = movieDataService;
        }

        public async Task<WatchlistDTO> CreateWatchlistAsync(WatchlistDTO watchlist)
        {
            var watchListDomain = new WatchlistDomain();

            watchListDomain.Name = watchlist.Name;
            watchListDomain.UserId = watchlist.UserId;
            watchListDomain.Movies = watchlist.Movies.Select(m => m.Id).ToList();

            var watchListDomainReturn = await _watchlistRepository.CreateWatchlistAsync(watchListDomain);

            var watchListDTO = new WatchlistDTO
            {
                Name = watchListDomainReturn.Name,
                UserId = watchListDomainReturn.UserId,
                Id = watchListDomainReturn.Id,
                Movies = watchlist.Movies
            };

            return watchListDTO;
        }


        public async Task<WatchlistDomain> GetWatchlistByIdAsync(int id)
        {
            return await _watchlistRepository.GetWatchlistByIdAsync(id);

        }



        public async Task<List<WatchlistDTO>> GetWatchlistsByUserIdAsync(string userId)
        {
            var watchListData = await _watchlistRepository.GetWatchlistsByUserIdAsync(userId);

            var DTOlist = new List<WatchlistDTO>();

            foreach (var watchlist in watchListData)
            {
                var DTO = new WatchlistDTO();
                DTO.Id = watchlist.Id;
                DTO.Name = watchlist.Name;
                DTO.UserId = watchlist.UserId;
                DTO.Movies = new List<MovieDTO>();

                foreach (var id in watchlist.Movies)
                {
                    var movieDTO = await _movieDataService.FindByIdAsync(id);
                    if (movieDTO != null)
                    {
                        DTO.Movies.Add(movieDTO);
                    }
                }
                DTOlist.Add(DTO);
            }
            return DTOlist;
        }

        public async Task<WatchlistDTO> UpdateWatchlistAsync(WatchlistDTO watchlist)
        {
            var watchlistDomain = await _watchlistRepository.GetWatchlistByIdAsync(watchlist.Id);
            if (watchlistDomain == null)
            {

                return null;
            }
            watchlistDomain.Movies.Clear();
            foreach (var movie in watchlist.Movies)
            {
                watchlistDomain.Movies.Add(movie.Id);
            }

            watchlistDomain.Name = watchlist.Name;
            var updatedWatchlistDomain = await _watchlistRepository.UpdateWatchlistAsync(watchlistDomain);


            var updatedWatchlistDto = new WatchlistDTO
            {
                Id = updatedWatchlistDomain.Id,
                Name = updatedWatchlistDomain.Name,
                UserId = updatedWatchlistDomain.UserId,
                Movies = new List<MovieDTO>(),
            };

            if (updatedWatchlistDomain.Movies.Count > 0)
            {
                foreach (var movie in updatedWatchlistDomain.Movies)
                {
                    var tempMovie = await _movieDataService.FindByIdAsync(movie);
                    updatedWatchlistDto.Movies.Add(tempMovie);
                }
            }
            return updatedWatchlistDto;

        }

        public async Task DeleteWatchlistAsync(int id)
        {
            await _watchlistRepository.DeleteWatchlistAsync(id);
        }
    }
}
