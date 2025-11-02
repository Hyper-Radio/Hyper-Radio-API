using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Repositories.CreatorRepositories
{
    public class CreatorRepository : ICreatorRepository
    {
        private readonly HyperRadioDbContext _context;
        public CreatorRepository(HyperRadioDbContext context)
        {
            _context = context;
        }
        public async Task<Creator?> CreateCreatorAsync(Creator creator)
        {
            _context.Creators.Add(creator);
            if (await _context.SaveChangesAsync() > 0)
            {
                return creator;
            }
            return null;
        }

        public async Task<bool> DeleteCreatorAsync(Creator creator)
        {
            _context.Creators.Remove(creator);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Creator>> GetAllCreatorsAsync()
        {
            return await _context.Creators.ToListAsync();
        }

        public async Task<Creator?> GetCreatorByIdAsync(int creatorId)
        {
            return await _context.Creators.FindAsync(creatorId);
        }

        public async Task<bool> UpdateCreatorAsync(Creator creator)
        {
            _context.Creators.Update(creator);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
