using Hyper_Radio_API.DTOs;
using Hyper_Radio_API.DTOs.ShowDTOs;
using Hyper_Radio_API.DTOs.TrackDTOs;
using Hyper_Radio_API.Services.ShowTrackServices;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers;

[Route("api/showtracks")]
[ApiController]

public class ShowTracksController : Controller
{
    private readonly IShowTrackService _context;

    public ShowTracksController(IShowTrackService context)
    {
        _context = context;
    }
    

    [HttpGet]
    public async Task<ActionResult<List<ReadShowTrackDTO>>> GetAllShowTracks()
    {
        var showTrack = await _context.GetAllShowTracksAsync();

        return Ok(showTrack);
    }


    [HttpGet("(id:int)")]
    public async Task<ActionResult<ReadShowTrackDTO>> GetShowTrackById(int id)
    {
        var showTrack = await _context.GetShowTrackByIdAsync(id);

        if (showTrack == null)
        {
            return NotFound();
        }

        return Ok(showTrack);
    }
    
    [HttpPost]
    public async Task<ActionResult<ReadShowTrackDTO>> CreateShowTrack(CreateShowTrackDTO showTrackDTO)
    {
        var showTrackId = await _context.CreateShowTrackAsync(showTrackDTO);

        return CreatedAtAction(nameof(GetAllShowTracks), new { id = showTrackId });
    }

}