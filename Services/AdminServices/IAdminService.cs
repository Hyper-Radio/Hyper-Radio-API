using Hyper_Radio_API.DTOs.AdminDTOs;

namespace Hyper_Radio_API.Services.AdminServices
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminDTO>> GetAllAdminsAsync();
        Task<AdminDTO?> GetAdminByIdAsync(int id);
        Task<AdminDTO?> CreateAdminAsync(CreateAdminDTO admin);
        Task<bool> UpdateAdminAsync(int id, AdminDTO admin);
        Task<bool> DeleteAdminAsync(int id);
    }
}
