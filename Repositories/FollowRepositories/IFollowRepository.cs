using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Repositories.FollowRepositories
{
    public interface IFollowRepository
    {
        Task<IEnumerable<Follow>> GetAllFollowsAsync();
        Task<Follow?> GetFollowByIdAsync(int followId);
        Task<bool> CreateFollowAsync(Follow follow);
        Task<bool> UpdateFollowAsync(Follow follow);
        Task<bool> DeleteFollowAsync(Follow follow);
    }
}
