using Hyper_Radio_API.DTOs.FavoriteDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.FavoriteRepositories;

namespace Hyper_Radio_API.Services.FavoriteServces
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        public async Task<IEnumerable<FavoriteDTO>> GetAllFavoritesAsync()
        {
            var favorites = await _favoriteRepository.GetAllFavoritesAsync();
            return favorites.Select(f => new FavoriteDTO
            {
                Id = f.Id,
                TrackId_FK = f.TrackId_FK,
                UserId_FK = f.UserId_FK
            });
        }
        public async Task<FavoriteDTO?> GetFavoriteByIdAsync(int id)
        {
            var favorite = await _favoriteRepository.GetFavoriteByIdAsync(id);

            if (favorite == null) { return null; }

            return new FavoriteDTO()
            {
                Id = favorite.Id,
                TrackId_FK = favorite.TrackId_FK,
                UserId_FK = favorite.UserId_FK
            };
        }
        public async Task<bool> CreateFavoriteAsync(CreateFavoriteDTO favorite)
        {
            Favorite newFavorite = new()
            {
                TrackId_FK = favorite.TrackId_FK,
                UserId_FK = favorite.UserId_FK
            };

            return await _favoriteRepository.CreateFavoriteAsync(newFavorite);
        }
        public async Task<bool> UpdateFavoriteAsync(int id, FavoriteDTO updated)
        {
            var existing = await _favoriteRepository.GetFavoriteByIdAsync(id);
            if (existing == null) { return false; }

            if (updated.TrackId_FK != null) { existing.TrackId_FK = updated.TrackId_FK.Value; }
            if (updated.UserId_FK != null) { existing.UserId_FK = updated.UserId_FK.Value; }

            return await _favoriteRepository.UpdateFavoriteAsync(existing);
        }
        public async Task<bool> DeleteFavoriteAsync(int id)
        {
            var favorite = await _favoriteRepository.GetFavoriteByIdAsync(id);
            if (favorite == null) { return false; }

            return await _favoriteRepository.DeleteFavoriteAsync(favorite);
        }
    }
}
