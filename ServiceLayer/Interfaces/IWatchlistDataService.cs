using DomainLayer.Entities;
using ServiceLayer.DTOs;

namespace ServiceLayer.Interfaces
{
    public interface IWatchlistDataService
    {
        Task<WatchlistDTO> CreateWatchlistAsync(WatchlistDTO watchlist);
        Task<WatchlistDomain> GetWatchlistByIdAsync(int id);
        Task<List<WatchlistDTO>> GetWatchlistsByUserIdAsync(string userId);
        Task<WatchlistDTO> UpdateWatchlistAsync(WatchlistDTO watchlist);
        Task DeleteWatchlistAsync(int id);
    }
}
