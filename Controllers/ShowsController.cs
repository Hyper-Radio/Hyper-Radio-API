using Hyper_Radio_API.DTOs.ShowDTOs;
using Hyper_Radio_API.Services.ShowServices;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers;

[Route("api/shows")]
[ApiController]
public class ShowsController : ControllerBase
{
    private readonly IShowService _service;

    public ShowsController(IShowService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadShowDTO>>> GetAllShows()
    {
        var shows = await _service.GetAllShowsAsync();
        return Ok(shows);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadShowDTO>> GetShowById(int id)
    {
        var show = await _service.GetShowByIdAsync(id);
        if (show == null)
            return NotFound();

        return Ok(show);
    }

    [HttpPost]
    public async Task<ActionResult> CreateShow([FromBody] CreateShowDTO showDTO)
    {
        var showId = await _service.CreateShowAsync(showDTO);
        return CreatedAtAction(nameof(GetShowById), new { id = showId }, null);
    }
    
    
    [HttpGet("{id:int}/playlist-urls")]
    public async Task<IActionResult> GetShowPlaylistUrls(int id)
    {
        // Fetch the show with its tracks
        var show = await _service.GetShowEntityByIdAsync(id);
        if (show == null)
            return NotFound();

        // Get ordered list of M3U8 URLs
        var playlistUrls = await _service.GetShowPlaylistUrlsAsync(show);

        return Ok(new { PlaylistUrls = playlistUrls });
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteShow(int id)
    {
        var deleted = await _service.DeleteShowAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }

    [HttpGet("{id:int}/tracks")]

    public async Task<ActionResult<ShowWithTrackDTO>> GetShowWithTracks(int id)
    {
        var showWithTracks = await _service.GetShowWithTracksAsync(id);
        if (showWithTracks == null)
            return NotFound();
        return Ok(showWithTracks);
    }
}