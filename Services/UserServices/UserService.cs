using Hyper_Radio_API.DTOs.UserDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.UserRepositories;

namespace Hyper_Radio_API.Services.UserServices
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                ProfilePictureURL = u.ProfilePictureURL
            });
        }
        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null) { return null; }

            return new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePictureURL = user.ProfilePictureURL
            };
        }
        public async Task<UserDTO?> CreateUserAsync(CreateUserDTO user)
        {
            User newUser = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ProfilePictureURL = user.ProfilePictureURL
            };

            var createdUser = await _userRepository.CreateUserAsync(newUser);

            if (createdUser == null) { return null; }

            return new UserDTO
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                ProfilePictureURL = createdUser.ProfilePictureURL
            };
        }
        public async Task<bool> UpdateUserAsync(int id, UserDTO updated)
        {
            var existing = await _userRepository.GetUserByIdAsync(id);
            if (existing == null) { return false; }

            if (updated.FirstName != null) { existing.FirstName = updated.FirstName; }
            if (updated.Email != null) { existing.Email = updated.Email; }
            if (updated.LastName != null) { existing.LastName = updated.LastName; }
            if (updated.ProfilePictureURL != null) { existing.ProfilePictureURL = updated.ProfilePictureURL; }

            return await _userRepository.UpdateUserAsync(existing);
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) { return false; }

            return await _userRepository.DeleteUserAsync(user);
        }
    }
}
