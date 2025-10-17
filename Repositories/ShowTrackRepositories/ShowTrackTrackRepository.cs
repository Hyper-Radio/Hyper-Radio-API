using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Repositories.ShowTrackRepositories;

public class ShowTrackTrackRepository : IShowTrackRepository
{

    private readonly HyperRadioDbContext _context;

    public ShowTrackTrackRepository(HyperRadioDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<ShowTrack>> GetAllShowTrackAsync()
    {
        var showTracks = await _context.ShowTracks.ToListAsync();
        return showTracks;
    }

    public async Task<ShowTrack> GetShowTrackByIdAsync(int showTrackId)
    {
        var showTrack = await _context.ShowTracks.FirstOrDefaultAsync(s => s.Id == showTrackId);
        return showTrack;
    }

    public async Task<int> CreateShowTrackAsync(ShowTrack showTrack)
    {
        await _context.ShowTracks.AddAsync(showTrack);
        await _context.SaveChangesAsync();
        
        return showTrack.Id;
    }

    public Task<ShowTrack> UpdateShowTrackAsync(ShowTrack showTrack)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteShowTrackAsync(int showTrackId)
    {
        throw new NotImplementedException();
    }
}