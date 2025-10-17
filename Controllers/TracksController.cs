using Hyper_Radio_API.DTOs.TrackDTOs;
using Hyper_Radio_API.Services.TrackServices;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers;

[Route("api/tracks")]
[ApiController]

public class TracksController : Controller
{
    private readonly ITrackService _context;

    public TracksController(ITrackService context)
    {
        _context = context;
    }
    

    [HttpGet]
    public async Task<ActionResult<List<ReadTrackDTO>>> GetAllTracks()
    {
        var track = await _context.GetAllTracksAsync();

        return Ok(track);
    }


    [HttpGet("(id:int)")]
    public async Task<ActionResult<ReadTrackDTO>> GetTrackById(int id)
    {
        var track = await _context.GetTrackByIdAsync(id);

        if (track == null)
        {
            return NotFound();
        }

        return Ok(track);
    }
    
    [HttpPost]
    public async Task<ActionResult<ReadTrackDTO>> CreateTrack(CreateTrackDTO trackDTO)
    {
        var trackId = _context.CreateTrackAsync(trackDTO);

        return CreatedAtAction(nameof(GetAllTracks), new { id = trackId });
    }
    
    
}