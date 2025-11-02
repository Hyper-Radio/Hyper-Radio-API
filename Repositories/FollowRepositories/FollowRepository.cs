using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Repositories.FollowRepositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly HyperRadioDbContext _context;
        public FollowRepository(HyperRadioDbContext context)
        {
            _context = context;
        }
        public async Task<Follow?> CreateFollowAsync(Follow follow)
        {
            _context.Follows.Add(follow);
            if (await _context.SaveChangesAsync() > 0)
            {
                return follow;
            }
            return null;
        }

        public async Task<bool> DeleteFollowAsync(Follow follow)
        {
            _context.Follows.Remove(follow);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Follow>> GetAllFollowsAsync()
        {
            return await _context.Follows.ToListAsync();
        }

        public async Task<Follow?> GetFollowByIdAsync(int followId)
        {
            return await _context.Follows.FindAsync(followId);
        }

        public async Task<bool> UpdateFollowAsync(Follow follow)
        {
            _context.Follows.Update(follow);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Follow>> GetFollowsByUserIdAsync(int userId)
        {
            return await _context.Follows.Where(f => f.UserId_FK == userId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Follow>> GetFollowsByCreatorIdAsync(int creatorId)
        {
            return await _context.Follows.Where(f => f.CreatorId_FK == creatorId)
                .ToListAsync();
        }
    }
}
