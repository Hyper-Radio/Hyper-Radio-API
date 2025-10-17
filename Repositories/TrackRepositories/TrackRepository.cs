using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Repositories;

public class TrackRepository : ITrackRepository
{

    private readonly HyperRadioDbContext _context;

    public TrackRepository(HyperRadioDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<Track>> GetAllTracksAsync()
    {
        var tracks = await _context.Tracks.ToListAsync();
        return tracks;
    }

    public async Task<Track> GetTrackByIdAsync(int trackId)
    {

        var track = await _context.Tracks.FirstOrDefaultAsync(t => t.Id == trackId);
        return track;
    }

    public async Task<int> CreateTrackAsync(Track track)
    {

        await _context.Tracks.AddAsync(track);
        await _context.SaveChangesAsync();

        return track.Id;
    }

    public Task<Track> UpdateTrackAsync(Track track)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTrackAsync(int trackId)
    {
        throw new NotImplementedException();
    }
}