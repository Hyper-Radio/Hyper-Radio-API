using Hyper_Radio_API.DTOs.ShowDTOs;
using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Services.ShowServices;

public interface IShowService
{
    
    //GET ALL SHOWS
    public Task<List<ReadShowDTO>> GetAllShowsAsync();
    
    //GET SHOWS BY ID
    public Task<ReadShowDTO> GetShowByIdAsync(int showDTOId);
    
    //CREATE SHOW
    public Task<int> CreateShowAsync(CreateShowDTO showDTO);
    
    //DELETE SHOW
    public Task<bool> DeleteShowAsync(int showIdDTO);
    
    //UPDATE SHOW
    public Task<bool> UpdateShowAsync(CreateShowDTO showDTO);
    

    //Gets back the whole Show entity used internally by ShowService
    public Task<Show?> GetShowEntityByIdAsync(int id);
    
    public Task<string> GenerateShowPlaylistAsync(Show show);

    
}