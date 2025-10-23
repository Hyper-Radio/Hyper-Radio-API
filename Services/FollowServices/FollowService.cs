using Hyper_Radio_API.DTOs.FollowDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.FollowRepositories;

namespace Hyper_Radio_API.Services.FollowServices
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        public FollowService(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }
        public async Task<IEnumerable<FollowDTO>> GetAllFollowsAsync()
        {
            var follows = await _followRepository.GetAllFollowsAsync();
            return follows.Select(f => new FollowDTO
            {
                Id = f.Id,
                CreatorId_FK = f.CreatorId_FK,
                UserId_FK = f.UserId_FK
            });
        }
        public async Task<FollowDTO?> GetFollowByIdAsync(int id)
        {
            var follow = await _followRepository.GetFollowByIdAsync(id);

            if (follow == null) { return null; }

            return new FollowDTO()
            {
                Id = follow.Id,
                CreatorId_FK = follow.CreatorId_FK,
                UserId_FK = follow.UserId_FK
            };
        }
        public async Task<bool> CreateFollowAsync(CreateFollowDTO follow)
        {
            Follow newFollow = new()
            {
                CreatorId_FK = follow.CreatorId_FK,
                UserId_FK = follow.UserId_FK
            };

            return await _followRepository.CreateFollowAsync(newFollow);
        }
        public async Task<bool> UpdateFollowAsync(int id, FollowDTO updated)
        {
            var existing = await _followRepository.GetFollowByIdAsync(id);
            if (existing == null) { return false; }

            if (updated.CreatorId_FK != null) { existing.CreatorId_FK = updated.CreatorId_FK.Value; }
            if (updated.UserId_FK != null) { existing.UserId_FK = updated.UserId_FK.Value; }

            return await _followRepository.UpdateFollowAsync(existing);
        }
        public async Task<bool> DeleteFollowAsync(int id)
        {
            var follow = await _followRepository.GetFollowByIdAsync(id);
            if (follow == null) { return false; }

            return await _followRepository.DeleteFollowAsync(follow);
        }
    }
}
