using Hyper_Radio_API.DTOs.FavoriteDTOs;

namespace Hyper_Radio_API.Services.FavoriteServces
{
    public interface IFavoriteService
    {
        Task<IEnumerable<FavoriteDTO>> GetAllFavoritesAsync();
        Task<FavoriteDTO?> GetFavoriteByIdAsync(int id);
        Task<bool> CreateFavoriteAsync(CreateFavoriteDTO favorite);
        Task<bool> UpdateFavoriteAsync(int id, FavoriteDTO favorite);
        Task<bool> DeleteFavoriteAsync(int id);
    }
}
