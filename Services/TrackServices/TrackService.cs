using Hyper_Radio_API.Data;
using Hyper_Radio_API.DTOs.TrackDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Services.TrackServices;

public class TrackService : ITrackService
{

    private readonly ITrackRepository _context;

    public TrackService(ITrackRepository context)
    {
        _context = context;
    }
    
    
    public async Task<List<ReadTrackDTO>> GetAllTracksAsync()
    {
        var tracks = await _context.GetAllTracksAsync();

        var tracksDTO = tracks.Select(t => new ReadTrackDTO
        {
            Id = t.Id,
            Title = t.Title,
            ReleaseYear = t.ReleaseYear,
            Genre = t.Genre,
            Description = t.Description,
            TrackURL = t.TrackURL,
            ImageURL = t.ImageURL,
            CreatorId_FK = t.CreatorId_FK
        }).ToList();

        return tracksDTO;
    }

    public async Task<ReadTrackDTO> GetTrackByIdAsync(int id)
    {
        var track = await _context.GetTrackByIdAsync(id);

        if (track == null)
        {
            return null;
        }

        var trackDTO = new ReadTrackDTO
        {
            Title = track.Title,
            ReleaseYear = track.ReleaseYear,
            Genre = track.Genre,
            Description = track.Description,
            TrackURL = track.TrackURL,
            ImageURL = track.ImageURL,
            CreatorId_FK = track.CreatorId_FK
        };

        return trackDTO;
    }

    public async Task<int> CreateTrackAsync(CreateTrackDTO trackDTO)
    {
        var track = new Track
        {
            Title = trackDTO.Title,
            ReleaseYear = trackDTO.ReleaseYear,
            Genre = trackDTO.Genre,
            Description = trackDTO.Description,
            TrackURL = trackDTO.TrackURL,
            ImageURL = trackDTO.ImageURL,
            CreatorId_FK = trackDTO.CreatorId_FK
        };
        
        var trackId = await _context.CreateTrackAsync(track);

        return trackId;
    }

    public Task<bool> DeleteTrackAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateTrackAsync(ReadTrackDTO trackDTO)
    {
        throw new NotImplementedException();
    }
}