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
        public async Task<bool> CreateFavoriteAsync(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            return await _context.SaveChangesAsync() > 0;
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
    }
}
