using Hyper_Radio_API.DTOs.UserDTOs;

namespace Hyper_Radio_API.Services.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<UserDTO?> CreateUserAsync(CreateUserDTO user);
        Task<bool> UpdateUserAsync(int id, UserDTO user);
        Task<bool> DeleteUserAsync(int id);
    }
}
