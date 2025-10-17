using Hyper_Radio_API.Data;
using Hyper_Radio_API.DTOs.ShowDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories;

namespace Hyper_Radio_API.Services.ShowServices;

public class ShowService : IShowService
{
    private readonly IShowRepository _context;

    public ShowService(IShowRepository context)
    {
        _context = context;
    }
    
    public async Task<List<ReadShowDTO>> GetAllShowsAsync()
    {
        var shows = await _context.GetAllShowsAsync();

        var showsDTO =  shows.Select(s => new ReadShowDTO
        {
            Id = s.Id,
            Name = s.Name,
            ScheduledStart = s.ScheduledStart,
            ShowTracks = s.ShowTracks
        }).ToList();

        return showsDTO;
    }

    public async Task<ReadShowDTO> GetShowByIdAsync(int id)
    {
        var show = await _context.GetShowByIdAsync(id);

        if (show == null)
        {
            return null;
        }

        var showDTO = new ReadShowDTO
        {
            Name = show.Name,
            ScheduledStart = show.ScheduledStart,
            ShowTracks = show.ShowTracks
        };
        
        return showDTO;
    }

    public async Task<int> CreateShowAsync(CreateShowDTO showDTO)
    {
        var show = new Show
        {
            Name = showDTO.Name,
            ScheduledStart = showDTO.ScheduledStart,
            ShowTracks = showDTO.ShowTracks
        };

        var newShowId = await _context.CreateShowAsync(show);

        return newShowId;
    }

    public Task<bool> DeleteShowAsync(int showIdDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateShowAsync(CreateShowDTO showDTO)
    {
        throw new NotImplementedException();
    }
}