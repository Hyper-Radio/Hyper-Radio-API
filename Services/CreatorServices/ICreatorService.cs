using Hyper_Radio_API.DTOs.CreatorDTOs;

namespace Hyper_Radio_API.Services.CreatorServices
{
    public interface ICreatorService
    {
        Task<IEnumerable<CreatorDTO>> GetAllCreatorsAsync();
        Task<CreatorDTO?> GetCreatorByIdAsync(int id);
        Task<CreatorDTO?> CreateCreatorAsync(CreateCreatorDTO creator);
        Task<bool> UpdateCreatorAsync(int id, CreatorDTO creator);
        Task<bool> DeleteCreatorAsync(int id);
    }
}
