using Hyper_Radio_API.DTOs;
using Hyper_Radio_API.DTOs.ShowDTOs;

namespace Hyper_Radio_API.Services.ShowTrackServices;

public interface IShowTrackService
{
    //GET ALL SHOWTRACKS
    public Task<IEnumerable<ReadShowTrackDTO>> GetAllShowTracksAsync();

    //GET SHOWTRACK BY ID
    public Task<ReadShowTrackDTO> GetShowTrackByIdAsync(int showDTOId);

    //CREATE SHOWTRACK
    public Task<int> CreateShowTrackAsync(CreateShowTrackDTO showTrackDTO);

    //DELETE SHOWTRACK
    public Task<bool> DeleteShowTrackAsync(int showTrackIdDTO);

    //UPDATE SHOWTRACK
    public Task<bool> UpdateShowTrackAsync(CreateShowTrackDTO showTrackDTO);
}
