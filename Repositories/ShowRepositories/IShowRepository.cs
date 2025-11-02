using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Repositories;

public interface IShowRepository
{

    //GET ALL SHOWS
    Task<List<Show>> GetAllShowsAsync();

    //GET SHOW BY ID
    Task<Show> GetShowByIdAsync(int showId);
    
    //CREATE SHOW
    Task<int> CreateShowAsync(Show show);
    
    //UPDATE SHOW
    Task<Show> UpdateShowAsync(Show show);
    
    //DELETE SHOW
    Task<bool> DeleteShowAsync(int showId);
    
    
    Task<Show> GetShowWithTracksAsync(int id);

    
    
}