using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Repositories.ShowTrackRepositories;

public interface IShowTrackRepository
{
    
    //GET ALL SHOWTRACKS
    Task<IEnumerable<ShowTrack>> GetAllShowTrackAsync();

    //GET SHOWTRACKS BY ID
    Task<ShowTrack> GetShowTrackByIdAsync(int showTrackId);
    
    //CREATE SHOWTRACKS
    Task<int> CreateShowTrackAsync(ShowTrack showTrack);
    
    //UPDATE SHOWTRACKS
    Task<ShowTrack> UpdateShowTrackAsync(ShowTrack showTrack);
    
    //DELETE SHOWTRACKS
    Task<bool> DeleteShowTrackAsync(int showTrackId);
    
}