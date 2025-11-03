using Hyper_Radio_API.DTOs.AdminDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.AdminRepositories;

namespace Hyper_Radio_API.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        public AdminService(IAdminRepository repository) 
        {
            _repository = repository;
        }
        public async Task<AdminDTO?> CreateAdminAsync(CreateAdminDTO admin)
        {
            //Change later
            Admin newAdmin = new() { Email = admin.Email, PasswordHash = admin.PasswordHash };

            var createdAdmin = await _repository.CreateAdminAsync(newAdmin);
            if (createdAdmin == null)
            {
                return null;
            }
            return new AdminDTO
            {
                Email = newAdmin.Email,
            };
        }

        public async Task<bool> DeleteAdminAsync(int id)
        {
            var admin = await _repository.GetAdminByIdAsync(id);

            if (admin == null)
            {
                return false;
            }

            return await _repository.DeleteAdminAsync(admin);
        }

        public async Task<AdminDTO?> GetAdminByIdAsync(int id)
        {
            var admin = await _repository.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return null;
            }
            AdminDTO adminDTO = new()
            {
                Email = admin.Email,
            };

            return adminDTO;
        }

        public async Task<IEnumerable<AdminDTO>> GetAllAdminsAsync()
        {
            var admins = await _repository.GetAllAdminsAsync();
            return admins.Select(a => new AdminDTO
            {
                Email = a.Email,
            });
        }

        public async Task<bool> UpdateAdminAsync(int id, AdminDTO admin)
        {
            var existing = await _repository.GetAdminByIdAsync(id);

            if (existing == null)
            {
                return false;
            }

            if (admin.Email != null)
            {
                existing.Email = admin.Email;
            }

            //if (admin.PasswordHash != null)
            //{
            //    existing.PasswordHash = admin.PasswordHash;
            //}

            return await _repository.UpdateAdminAsync(existing);
        }
    }
}
