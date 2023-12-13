using DataAccessLayer.DbContextFolder;
using DataAccessLayer.Interfaces;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly AppDbContext _context;

        public WatchlistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<WatchlistDomain> CreateWatchlistAsync(WatchlistDomain watchlist)
        {
            _context.Watchlists.Add(watchlist);
            await _context.SaveChangesAsync();
            return watchlist;
        }

        public async Task<WatchlistDomain> GetWatchlistByIdAsync(int id)
        {
            return await _context.Watchlists.FindAsync(id);
        }

        public async Task<IEnumerable<WatchlistDomain>> GetWatchlistsByUserIdAsync(string userId)
        {
            return await _context.Watchlists
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }

        public async Task<WatchlistDomain> UpdateWatchlistAsync(WatchlistDomain watchlist)
        {
            _context.Entry(watchlist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return watchlist;
        }

        public async Task DeleteWatchlistAsync(int id)
        {
            var watchlist = await _context.Watchlists.FindAsync(id);
            if (watchlist != null)
            {
                _context.Watchlists.Remove(watchlist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
