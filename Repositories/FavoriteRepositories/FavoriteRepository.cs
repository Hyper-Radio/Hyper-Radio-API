using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Repositories.FavoriteRepositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly HyperRadioDbContext _context;
        public FavoriteRepository(HyperRadioDbContext context)
        {
            _context = context;
        }
        public async Task<Favorite?> CreateFavoriteAsync(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            if (await _context.SaveChangesAsync() > 0)
            {
                return favorite;
            }
            return null;
        }

        public async Task<bool> DeleteFavoriteAsync(Favorite favorite)
        {
            _context.Favorites.Remove(favorite);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Favorite>> GetAllFavoritesAsync()
        {
            return await _context.Favorites.ToListAsync();
        }

        public async Task<Favorite?> GetFavoriteByIdAsync(int favoriteId)
        {
            return await _context.Favorites.FindAsync(favoriteId);
        }

        public async Task<bool> UpdateFavoriteAsync(Favorite favorite)
        {
            _context.Favorites.Update(favorite);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId)
        {
            return await _context.Favorites.Where(f => f.UserId_FK == userId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Favorite>> GetFavoritesByTrackIdAsync(int trackId)
        {
            return await _context.Favorites.Where(f => f.TrackId_FK == trackId)
                .ToListAsync();
        }
    }
}
