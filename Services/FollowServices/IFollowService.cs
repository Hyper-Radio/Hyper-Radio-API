using Hyper_Radio_API.DTOs.FollowDTOs;

namespace Hyper_Radio_API.Services.FollowServices
{
    public interface IFollowService
    {
        Task<IEnumerable<FollowDTO>> GetAllFollowsAsync();
        Task<FollowDTO?> GetFollowByIdAsync(int id);
        Task<bool> CreateFollowAsync(CreateFollowDTO follow);
        Task<bool> UpdateFollowAsync(int id, FollowDTO follow);
        Task<bool> DeleteFollowAsync(int id);
    }
}
