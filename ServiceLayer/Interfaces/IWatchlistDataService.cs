using DomainLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IWatchlistDataService
    {
        Task<WatchlistDomain> CreateWatchlistAsync(WatchlistDomain watchlist);
        Task<WatchlistDomain> GetWatchlistByIdAsync(int id);
        Task<IEnumerable<WatchlistDomain>> GetWatchlistsByUserIdAsync(string userId);
        Task UpdateWatchlistAsync(WatchlistDomain watchlist);
        Task DeleteWatchlistAsync(int id);
    }
}
