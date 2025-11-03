using Hyper_Radio_API.DTOs.FavoriteDTOs;
using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Services.FavoriteServices
{
    public interface IFavoriteService
    {
        Task<IEnumerable<FavoriteDTO>> GetAllFavoritesAsync();
        Task<FavoriteDTO?> GetFavoriteByIdAsync(int id);
        Task<IEnumerable<FavoriteDTO>> GetFavoritesByUserIdAsync(int userId);
        Task<IEnumerable<FavoriteDTO>> GetFavoritesByTrackIdAsync(int trackId);
        Task<FavoriteDTO?> CreateFavoriteAsync(CreateFavoriteDTO favorite);
        Task<bool> UpdateFavoriteAsync(int id, FavoriteDTO favorite);
        Task<bool> DeleteFavoriteAsync(int id);
    }
}
