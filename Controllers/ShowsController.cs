using Hyper_Radio_API.DTOs.ShowDTOs;
using Hyper_Radio_API.Services.ShowServices;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers;

[Route("api/shows")]
[ApiController]
public class ShowsController : ControllerBase
{
    private readonly IShowService _context;

    public ShowsController(IShowService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadShowDTO>>> GetAllShows()
    {
        var shows = await _context.GetAllShowsAsync();
        return Ok(shows);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShowWithTracksDTO>> GetShowById(int id)
    {
        var show = await _context.GetShowByIdAsync(id);
        if (show == null)
            return NotFound();

        return Ok(show);
    }

    [HttpPost]
    public async Task<ActionResult> CreateShow([FromBody] CreateShowDTO showDTO)
    {
        var showId = await _context.CreateShowAsync(showDTO);
        return CreatedAtAction(nameof(GetShowById), new { id = showId }, null);
    }
    
    
    [HttpGet("{id:int}/playlist-urls")]
    public async Task<IActionResult> GetShowPlaylistUrls(int id)
    {
        // Fetch the show with its tracks
        var show = await _context.GetShowEntityByIdAsync(id);
        if (show == null)
            return NotFound();

        // Get ordered list of M3U8 URLs
        var playlistUrls = await _context.GetShowPlaylistUrlsAsync(show);

        return Ok(new { PlaylistUrls = playlistUrls });
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteShow(int id)
    {
        var deleted = await _context.DeleteShowAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}