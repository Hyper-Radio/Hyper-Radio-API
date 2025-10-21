using Hyper_Radio_API.DTOs.TrackDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.TrackRepositories;

namespace Hyper_Radio_API.Services.TrackServices
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }
        public async Task<IEnumerable<TrackDTO>> GetAllTracksAsync()
        {
            var tracks = await _trackRepository.GetAllTracksAsync();
            return tracks.Select(t => new TrackDTO
            {
                Id = t.Id,
                Title = t.Title,
                ReleaseYear = t.ReleaseYear,
                Genre = t.Genre,
                Description = t.Description,
                Duration = t.Duration,
                TrackURL = t.TrackURL,
                ImageURL = t.ImageURL,
                CreatorId_FK = t.CreatorId_FK
            });
        }
        public async Task<TrackDTO?> GetTrackByIdAsync(int id)
        {
            var track = await _trackRepository.GetTrackByIdAsync(id);

            if (track == null) return null;

            return new TrackDTO
            {
                Id = track.Id,
                Title = track.Title,
                ReleaseYear = track.ReleaseYear,
                Genre = track.Genre,
                Description = track.Description,
                Duration = track.Duration,
                TrackURL = track.TrackURL,
                ImageURL = track.ImageURL,
                CreatorId_FK = track.CreatorId_FK
            };
        }
        public async Task<TrackDTO?> CreateTrackAsync(CreateTrackDTO track)
        {
            var createTrack = new Track
            {
                Title = track.Title,
                ReleaseYear = track.ReleaseYear,
                Genre = track.Genre,
                Description = track.Description,
                Duration = track.Duration,
                TrackURL = track.TrackURL,
                ImageURL = track.ImageURL,
                CreatorId_FK = track.CreatorId_FK
            };
            _trackRepository.CreateTrack(createTrack);

            if (await _trackRepository.SaveChangesAsync())
            {
                return new TrackDTO
                {
                    Id = createTrack.Id,
                    Title = createTrack.Title,
                    ReleaseYear = createTrack.ReleaseYear,
                    Genre = createTrack.Genre,
                    Description = createTrack.Description,
                    Duration = createTrack.Duration,
                    TrackURL = createTrack.TrackURL,
                    ImageURL = createTrack.ImageURL,
                    CreatorId_FK = createTrack.CreatorId_FK
                };
            }
            return null;
        }
        public async Task<bool> UpdateTrackAsync(int id, UpdateTrackDTO track)
        {
            var existingTrack = await _trackRepository.GetTrackByIdAsync(id);

            if (existingTrack == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(track.Title))
            {
                existingTrack.Title = track.Title;
            }

            if (track.ReleaseYear != 0)
            {
                existingTrack.ReleaseYear = track.ReleaseYear.Value;
            }

            if (!string.IsNullOrEmpty(track.Genre))
            {
                existingTrack.Genre = track.Genre;
            }

            if (!string.IsNullOrEmpty(track.Description))
            {
                existingTrack.Description = track.Description;
            }

            if (track.Duration != 0)
            {
                existingTrack.Duration = track.Duration.Value;
            }

            if (!string.IsNullOrEmpty(track.TrackURL))
            {
                existingTrack.TrackURL = track.TrackURL;
            }

            if (!string.IsNullOrEmpty(track.ImageURL))
            {
                existingTrack.ImageURL = track.ImageURL;
            }

            if (track.CreatorId_FK != 0)
            {
                existingTrack.CreatorId_FK = track.CreatorId_FK.Value;
            }

            _trackRepository.UpdateTrack(existingTrack);
            return await _trackRepository.SaveChangesAsync();
        }
        public async Task<bool> DeleteTrackAsync(int id)
        {
            var track = await _trackRepository.GetTrackByIdAsync(id);

            if (track == null) return false;

            _trackRepository.DeleteTrack(track);
            return await _trackRepository.SaveChangesAsync();
        }
    }
}
