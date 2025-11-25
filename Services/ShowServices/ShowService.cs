using System.Text;
using Hyper_Radio_API.DTOs.ShowDTOs;
using Hyper_Radio_API.DTOs.TrackDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Repositories;
using Hyper_Radio_API.Services.UploadServices;

namespace Hyper_Radio_API.Services.ShowServices;

public class ShowService : IShowService
{
    private readonly IShowRepository _context;
    private readonly AzureBlobService _blob;

    
    public ShowService(IShowRepository context, AzureBlobService blob)
    {
        _context = context;
        _blob = blob;
    }

    public async Task<List<ReadShowDTO>> GetAllShowsAsync()
    {
        var shows = await _context.GetAllShowsAsync();
        return shows.Select(s => new ReadShowDTO
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            ScheduledStart = s.ScheduledStart,
            ShowTracks = s.ShowTracks
        }).ToList();
    }

    
    public async Task<ShowWithTracksDTO?> GetShowByIdAsync(int id)
    {
        var show = await _context.GetShowByIdAsync(id);
        var tracks = await GetTracksByShowIdAsync(id);
        if (show == null) return null;

        return new ShowWithTracksDTO
        {
            Id = show.Id,
            Name = show.Name,
            Description = show.Description,
            Tracks = tracks
        };
    }


    public async Task<Show> GetShowEntityByIdAsync(int id)
    {
        var show = await _context.GetShowWithTracksAsync(id);
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

        var newShowId = await _context.CreateShowAsync(show);
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

    public async Task<List<TrackDTO>> GetTracksByShowIdAsync(int id)
    {
        var show = await GetShowEntityByIdAsync(id);
        var trackDTOs = show.ShowTracks
            .OrderBy(st => st.Order)
            .Select(st => new TrackDTO
            {
                Id = st.Track.Id,
                Title = st.Track.Title,
                ReleaseYear = st.Track.ReleaseYear,
                Genre = st.Track.Genre,
                Duration = st.Track.Duration,
                TrackURL = st.Track.TrackURL,
                CreatorId_FK = st.Track.CreatorId_FK,
                ImageURL = st.Track.ImageURL
            })
            .ToList();

        return trackDTOs;
    }
        

public Task<bool> DeleteShowAsync(int showIdDTO)
    => throw new NotImplementedException();

public Task<bool> UpdateShowAsync(CreateShowDTO showDTO)
    => throw new NotImplementedException();



 
 
}