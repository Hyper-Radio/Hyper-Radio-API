using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Repositories;

public interface ITrackRepository
{
    //GET ALL TRACK
    Task<List<Track>> GetAllTracksAsync();

    //GET TRACK BY ID
    Task<Track> GetTrackByIdAsync(int trackId);
    
    //CREATE TRACK
    Task<int> CreateTrackAsync(Track track);
    
    //UPDATE TRACK
    Task<Track> UpdateTrackAsync(Track track);
    
    //DELETE TRACK
    Task<bool> DeleteTrackAsync(int trackId);
}