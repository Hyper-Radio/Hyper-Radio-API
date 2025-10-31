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
    public async Task<ActionResult<ReadShowDTO>> GetShowById(int id)
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

    [HttpPost("{id:int}/generate-playlist")]
    public async Task<IActionResult> GenerateShowPlaylist(int id)
    {
        var show = await _context.GetShowEntityByIdAsync(id); // make sure this exists
        if (show == null)
            return NotFound();

        var playlistUrl = await _context.GenerateShowPlaylistAsync(show);
        return Ok(new { PlaylistUrl = playlistUrl });
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