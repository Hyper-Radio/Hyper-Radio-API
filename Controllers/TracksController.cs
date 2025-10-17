using Hyper_Radio_API.DTOs;
using Hyper_Radio_API.Services.TrackServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _trackService;
        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackDTO>>> GetAllTracks()
        {
            var tracks = await _trackService.GetAllTracksAsync();
            return Ok(tracks);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TrackDTO>> GetTrackById(int id)
        {
            var track = await _trackService.GetTrackByIdAsync(id);
            if (track == null)
            {
                return NotFound();
            }
            return Ok(track);
        }
        [HttpPost]
        public async Task<ActionResult<TrackDTO>> CreateTrack([FromBody] CreateTrackDTO track)
        {
            var createdTrack = await _trackService.CreateTrackAsync(track);

            if (createdTrack == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetTrackById), new { id = createdTrack.Id }, createdTrack);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTrack(int id, [FromBody] UpdateTrackDTO track)
        {
            var result = await _trackService.UpdateTrackAsync(id, track);
            if (!result) 
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var result = await _trackService.DeleteTrackAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
