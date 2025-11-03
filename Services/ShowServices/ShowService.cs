using System.Text;
using Hyper_Radio_API.DTOs.ShowDTOs;
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

    
    public async Task<ReadShowDTO?> GetShowByIdAsync(int id)
    {
        var show = await _context.GetShowByIdAsync(id);
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

    public Task<bool> DeleteShowAsync(int showIdDTO)
        => throw new NotImplementedException();

    public Task<bool> UpdateShowAsync(CreateShowDTO showDTO)
        => throw new NotImplementedException();

    
    
    //GENERATE A SHOW 
 public async Task<string> GenerateShowPlaylistAsync(Show show)
{
    if (show.ShowTracks == null || !show.ShowTracks.Any())
        throw new InvalidOperationException("Show has no tracks.");

    var builder = new StringBuilder();
    builder.AppendLine("#EXTM3U");
    builder.AppendLine("#EXT-X-VERSION:3");

    foreach (var showTrack in show.ShowTracks.OrderBy(t => t.Order))
    {
        var playlistUrl = showTrack.Track.TrackURL;
        if (string.IsNullOrEmpty(playlistUrl))
            continue;

        // Download the track's m3u8
        var playlistText = await _blob.DownloadTextAsync(playlistUrl);

        // Extract base path from URL for relative .ts files
        var basePath = Path.GetDirectoryName(playlistUrl)?.Replace("\\", "/");
        if (!string.IsNullOrEmpty(basePath) && !basePath.EndsWith("/"))
            basePath += "/";

        var lines = playlistText.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            // Skip playlist headers
            if (line.StartsWith("#EXTM3U") || line.StartsWith("#EXT-X-VERSION") ||
                line.StartsWith("#EXT-X-TARGETDURATION") || line.StartsWith("#EXT-X-MEDIA-SEQUENCE"))
                continue;

            if (line.StartsWith("#EXTINF"))
            {
                builder.AppendLine(line);
                continue;
            }

            if (line.EndsWith(".ts"))
            {
                // Convert relative paths to full URLs
                var segmentUrl = line.StartsWith("http")
                    ? line
                    : $"{basePath}{line}".Replace(" ", "%20"); // encode spaces
                if (!segmentUrl.StartsWith("http"))
                    segmentUrl = "https://" + segmentUrl.TrimStart('/'); // ensure https://
                builder.AppendLine(segmentUrl);
                continue;
            }

            builder.AppendLine(line);
        }

        // Add discontinuity and custom fade info for this track
        builder.AppendLine("#EXT-X-DISCONTINUITY");
        builder.AppendLine($"#EXT-X-CUSTOM:FADEIN={showTrack.FadeIn:F1},FADEOUT={showTrack.FadeOut:F1}");
    }

    builder.AppendLine("#EXT-X-ENDLIST");

    // Upload the generated playlist to Azure Blob
    var bytes = Encoding.UTF8.GetBytes(builder.ToString());
    await using var stream = new MemoryStream(bytes);

    return await _blob.UploadFileAsync(
        stream,
        $"shows/{show.Id}/show.m3u8",
        "application/vnd.apple.mpegurl"
    );
}
 
 
}