using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Repositories.FavoriteRepositories
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetAllFavoritesAsync();
        Task<Favorite?> GetFavoriteByIdAsync(int favoriteId);
        Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(int userId);
        Task<IEnumerable<Favorite>> GetFavoritesByTrackIdAsync(int trackId);
        Task<Favorite?> CreateFavoriteAsync(Favorite favorite);
        Task<bool> UpdateFavoriteAsync(Favorite favorite);
        Task<bool> DeleteFavoriteAsync(Favorite favorite);
    }
}
