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
        public async Task<bool> CreateFollowAsync(Follow follow)
        {
            _context.Follows.Add(follow);
            return await _context.SaveChangesAsync() > 0;
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
    }
}
