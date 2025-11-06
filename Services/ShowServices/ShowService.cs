using System.Text;
using Hyper_Radio_API.DTOs.ShowDTOs;
using Hyper_Radio_API.DTOs.TrackDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories;
using Hyper_Radio_API.Services.UploadServices;

namespace Hyper_Radio_API.Services.ShowServices;

public class ShowService : IShowService
{
    private readonly IShowRepository _showRepository;
    private readonly AzureBlobService _blob;

    
    public ShowService(IShowRepository showRepository, AzureBlobService blob)
    {
        _showRepository = showRepository;
        _blob = blob;
    }

    public async Task<List<ReadShowDTO>> GetAllShowsAsync()
    {
        var shows = await _showRepository.GetAllShowsAsync();
        return shows.Select(s => new ReadShowDTO
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            ScheduledStart = s.ScheduledStart,
            ShowTracks = s.ShowTracks
        }).ToList();
    }

    
    public async Task<ReadShowDTO?> GetShowByIdAsync(int id)
    {
        var show = await _showRepository.GetShowByIdAsync(id);
        if (show == null) return null;

        return new ReadShowDTO
        {
            Id = show.Id,
            Name = show.Name,
            Description = show.Description,
            ScheduledStart = show.ScheduledStart,
            ShowTracks = show.ShowTracks
        };
    }


    public async Task<Show> GetShowEntityByIdAsync(int id)
    {
        var show = await _showRepository.GetShowWithTracksAsync(id);
        return show ?? throw new InvalidOperationException("Show not found.");
    }
    
    
    public async Task<int> CreateShowAsync(CreateShowDTO showDTO)
    {
        var show = new Show
        {
            Name = showDTO.Name,
            Description = showDTO.Description,
            ScheduledStart = showDTO.ScheduledStart,
            ShowTracks = showDTO.ShowTracks.Select(st => new ShowTrack
            {
                TrackId = st.TrackId,
                Order = st.Order,
                FadeIn = st.FadeIn,
                FadeOut = st.FadeOut
            }).ToList()
        };

        var newShowId = await _showRepository.CreateShowAsync(show);
        return newShowId;
    }


    public async Task<List<string>> GetShowPlaylistUrlsAsync(Show show)
    {
        if (show.ShowTracks == null || !show.ShowTracks.Any())
            throw new InvalidOperationException("Show has no tracks.");

        // Order tracks by their display order
        var playlistUrls = show.ShowTracks
            .OrderBy(t => t.Order)
            .Select(t => t.Track.TrackURL)
            .Where(url => !string.IsNullOrEmpty(url))
            .ToList();

        return playlistUrls;
    }


public Task<bool> DeleteShowAsync(int showIdDTO)
    => throw new NotImplementedException();

public Task<bool> UpdateShowAsync(CreateShowDTO showDTO)
    => throw new NotImplementedException();

public async Task<ShowWithTrackDTO?> GetShowWithTracksAsync(int showId)
    {
        var show = await _showRepository.GetShowByIdAsync(showId);
        if (show == null) return null;
        var tracks = await _showRepository.GetTracksByShowIdAsync(showId);

        return new ShowWithTrackDTO
        {
            Id = show.Id,
            Name = show.Name,
            Description = show.Description,
            Tracks = tracks.Select(t => new TrackDTO
            {
                Id = t.Id,
                Title = t.Title,
                ReleaseYear = t.ReleaseYear,
                Genre = t.Genre,
                Description = t.Description,
                Duration = t.Duration,
                TrackURL = t.TrackURL,
                ImageURL = t.ImageURL
            }).ToList()
        };
    }

 
 
}