using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Repositories.CreatorRepositories
{
    public interface ICreatorRepository
    {
        Task<IEnumerable<Creator>> GetAllCreatorsAsync();
        Task<Creator?> GetCreatorByIdAsync(int creatorId);
        Task<bool> CreateCreatorAsync(Creator creator);
        Task<bool> UpdateCreatorAsync(Creator creator);
        Task<bool> DeleteCreatorAsync(Creator creator);
    }
}
