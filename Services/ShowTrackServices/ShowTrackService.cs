using Hyper_Radio_API.DTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.ShowTrackRepositories;

namespace Hyper_Radio_API.Services.ShowTrackServices;

public class ShowTrackService : IShowTrackService
{

    private readonly IShowTrackRepository _context;

    public ShowTrackService(IShowTrackRepository context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ReadShowTrackDTO>> GetAllShowTracksAsync()
    {
        var showTracks = await _context.GetAllShowTrackAsync();

        var showTracksDTO = showTracks.Select(s => new ReadShowTrackDTO
        {
            Id = s.Id,
            Track = s.Track,
            Order = s.Order,
            FadeIn = s.FadeIn,
            FadeOut = s.FadeOut
        }).ToList();
        
        return showTracksDTO;
    }

    public async Task<ReadShowTrackDTO?> GetShowTrackByIdAsync(int id)
    {
        var showTrack = await _context.GetShowTrackByIdAsync(id);

        if (showTrack == null)
        {
            return null;
        }

        var showTrackDTO = new ReadShowTrackDTO
        {
            Track = showTrack.Track,
            Order = showTrack.Order,
            FadeIn = showTrack.FadeIn,
            FadeOut = showTrack.FadeOut
        };

        return showTrackDTO;
    }

    
    
    public async Task<int> CreateShowTrackAsync(CreateShowTrackDTO showTrackDTO)
    {
        var showTrack = new ShowTrack
        {
            Track = showTrackDTO.Track,
            Order = showTrackDTO.Order,
            FadeIn = showTrackDTO.FadeIn,
            FadeOut = showTrackDTO.FadeOut
        };

        var newShowTrackId = await _context.CreateShowTrackAsync(showTrack);

        return newShowTrackId;
        
    }

    public Task<bool> DeleteShowTrackAsync(int showTrackIdDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateShowTrackAsync(CreateShowTrackDTO showTrackDTO)
    {
        throw new NotImplementedException();
    }
}