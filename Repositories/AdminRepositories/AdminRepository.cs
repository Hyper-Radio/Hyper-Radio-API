using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Repositories.AdminRepositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly HyperRadioDbContext _context;
        public AdminRepository(HyperRadioDbContext context)
        {
            _context = context;
        }
        public async Task<Admin?> CreateAdminAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            if (await _context.SaveChangesAsync() > 0)
            { 
                return admin;
            }
            return null;
        }

        public async Task<bool> DeleteAdminAsync(Admin admin)
        {
            _context.Admins.Remove(admin);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin?> GetAdminByIdAsync(int adminId)
        {
            return await _context.Admins.FindAsync(adminId);
        }

        public async Task<bool> UpdateAdminAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
