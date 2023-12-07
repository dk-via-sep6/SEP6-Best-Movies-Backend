using DomainLayer.Entities;


namespace DataAccessLayer.Interfaces
{
    public interface IWatchlistRepository
    {
        Task<WatchlistDomain> CreateWatchlistAsync(WatchlistDomain watchlist);
        Task<WatchlistDomain> GetWatchlistByIdAsync(int id);
        Task<IEnumerable<WatchlistDomain>> GetWatchlistsByUserIdAsync(string userId);
        Task UpdateWatchlistAsync(WatchlistDomain watchlist);
        Task DeleteWatchlistAsync(int id);
    }
}
