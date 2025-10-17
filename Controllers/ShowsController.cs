using Hyper_Radio_API.DTOs.ShowDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Services.ShowServices;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers;



[Route("api/shows")]
[ApiController]

public class ShowsController : Controller
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


    [HttpGet("(id:int)")]
    public async Task<ActionResult<ReadShowDTO>> GetShowById(int id)
    {
        var show = await _context.GetShowByIdAsync(id);

        if (show == null)
        {
            return NotFound();
        }

        return Ok(show);
    }
    
    [HttpPost]
    public async Task<ActionResult<ReadShowDTO>> CreateShow(CreateShowDTO showDTO)
    {
        var showId = _context.CreateShowAsync(showDTO);

        return CreatedAtAction(nameof(GetAllShows), new { id = showId });
    }

}