using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HyperRadioDbContext _context;
        public UserRepository(HyperRadioDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
