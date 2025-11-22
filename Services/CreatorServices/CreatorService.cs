using Hyper_Radio_API.DTOs.CreatorDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.CreatorRepositories;

namespace Hyper_Radio_API.Services.CreatorServices
{
    public class CreatorService : ICreatorService
    {
        private readonly ICreatorRepository _creatorRepository;
        public CreatorService(ICreatorRepository creatorRepository)
        {
            _creatorRepository = creatorRepository;
        }
        public async Task<IEnumerable<CreatorDTO>> GetAllCreatorsAsync()
        {
            var creators = await _creatorRepository.GetAllCreatorsAsync();
            return creators.Select(c => new CreatorDTO
            {
                Id = c.Id,
                Username = c.Username,
                Email = c.Email,
                Description = c.Description,
                ProfilePictureURL = c.ProfilePictureURL
            });
        }
        public async Task<CreatorDTO?> GetCreatorByIdAsync(int id)
        {
            var creator = await _creatorRepository.GetCreatorByIdAsync(id);

            if (creator == null) { return null; }

            return new CreatorDTO()
            {
                Id = creator.Id,
                Username = creator.Username,
                Email = creator.Email,
                Description = creator.Description,
                ProfilePictureURL = creator.ProfilePictureURL
            };
        }
        public async Task<CreatorDTO?> CreateCreatorAsync(CreateCreatorDTO creator)
        {
            Creator newCreator = new()
            {
                Username = creator.Username,
                Email = creator.Email,
                Description = creator.Description,
                PasswordHash = creator.PasswordHash,
                ProfilePictureURL = creator.ProfilePictureURL
            };

            var createdCreator = await _creatorRepository.CreateCreatorAsync(newCreator);
            if (createdCreator == null) { return null; }
            return new CreatorDTO
            {
                Id = newCreator.Id,
                Username = newCreator.Username,
                Email = newCreator.Email,
                Description = newCreator.Description,
                ProfilePictureURL = newCreator.ProfilePictureURL
            };
        }
        public async Task<bool> UpdateCreatorAsync(int id, CreatorDTO updated)
        {
            var existing = await _creatorRepository.GetCreatorByIdAsync(id);
            if (existing == null) { return false; }

            if (updated.Username != null) { existing.Username = updated.Username; }
            if (updated.Email != null) { existing.Email = updated.Email; }
            if (updated.Description != null) { existing.Description = updated.Description; }
            if (updated.ProfilePictureURL != null) { existing.ProfilePictureURL = updated.ProfilePictureURL; }

            return await _creatorRepository.UpdateCreatorAsync(existing);
        }
        public async Task<bool> DeleteCreatorAsync(int id)
        {
            var creator = await _creatorRepository.GetCreatorByIdAsync(id);
            if (creator == null) { return false; }

            return await _creatorRepository.DeleteCreatorAsync(creator);
        }
    }
}
