using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Repositories.AdminRepositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin?> GetAdminByIdAsync(int adminId);
        Task<Admin?> CreateAdminAsync(Admin admin);
        Task<bool> UpdateAdminAsync(Admin admin);
        Task<bool> DeleteAdminAsync(Admin admin);
    }
}
