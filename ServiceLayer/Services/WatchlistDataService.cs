using DataAccessLayer.Interfaces;
using DomainLayer.Entities;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class WatchlistDataService : IWatchlistDataService
    {
        private readonly IWatchlistRepository _watchlistRepository;

        public WatchlistDataService(IWatchlistRepository watchlistRepository)
        {
            _watchlistRepository = watchlistRepository;
        }

        public async Task<WatchlistDomain> CreateWatchlistAsync(WatchlistDomain watchlist)
        {
            return await _watchlistRepository.CreateWatchlistAsync(watchlist);
        }

        public async Task<WatchlistDomain> GetWatchlistByIdAsync(int id)
        {
            return await _watchlistRepository.GetWatchlistByIdAsync(id);
        }

        public async Task<IEnumerable<WatchlistDomain>> GetWatchlistsByUserIdAsync(string userId)
        {
            return await _watchlistRepository.GetWatchlistsByUserIdAsync(userId);
        }

        public async Task UpdateWatchlistAsync(WatchlistDomain watchlist)
        {
            await _watchlistRepository.UpdateWatchlistAsync(watchlist);
        }

        public async Task DeleteWatchlistAsync(int id)
        {
            await _watchlistRepository.DeleteWatchlistAsync(id);
        }
    }
}
