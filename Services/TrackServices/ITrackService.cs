using Hyper_Radio_API.DTOs.TrackDTOs;
using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Services.TrackServices;

public interface ITrackService
{
    //GET TRACKS
    public Task<List<ReadTrackDTO>> GetAllTracksAsync();

    //GET TRACK BY ID
    public Task<ReadTrackDTO> GetTrackByIdAsync(int trackDTOId);

    //CREATE TRACK
    public Task<int> CreateTrackAsync(CreateTrackDTO trackDTO);

    //DELETE TRACK
    public Task<bool> DeleteTrackAsync(int trackIdDTO);

    //UPDATE TRACK
    public Task<bool> UpdateTrackAsync(ReadTrackDTO trackDTO);

}
