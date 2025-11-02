using Hyper_Radio_API.DTOs.FollowDTOs;
using Hyper_Radio_API.Models;


namespace Hyper_Radio_API.Services.FollowServices
{
    public interface IFollowService
    {
        Task<IEnumerable<FollowDTO>> GetAllFollowsAsync();
        Task<FollowDTO?> GetFollowByIdAsync(int id);
        Task<IEnumerable<Follow>> GetFollowsByUserIdAsync(int userId);
        Task<IEnumerable<Follow>> GetFollowsByCreatorIdAsync(int creatorId);
        Task<FollowDTO?> CreateFollowAsync(CreateFollowDTO follow);
        Task<bool> UpdateFollowAsync(int id, FollowDTO follow);
        Task<bool> DeleteFollowAsync(int id);
    }
}
