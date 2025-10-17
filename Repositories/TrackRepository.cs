using Hyper_Radio_API.Data;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Hyper_Radio_API.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly HyperRadioDbContext _context;
        public TrackRepository(HyperRadioDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Track>> GetAllTracksAsync()
        {
            return await _context.Tracks.ToListAsync();
        }
        public async Task<Track?> GetTrackByIdAsync(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        public void CreateTrack(Track track)
        {
            _context.Tracks.Add(track);
        }
        public void UpdateTrack( Track track)
        {
             _context.Tracks.Update(track);
        }

        public void DeleteTrack(Track track)
        {
            _context.Remove(track);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
