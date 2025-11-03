using Hyper_Radio_API.DTOs.FollowDTOs;
using Hyper_Radio_API.Services.FollowServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly IFollowService _followService;
        public FollowsController(IFollowService followService)
        {
            _followService = followService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowDTO>>> GetAllFollows()
        {
            var follows = await _followService.GetAllFollowsAsync();
            return Ok(follows);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FollowDTO?>> GetFollowById(int id)
        {
            var follow = await _followService.GetFollowByIdAsync(id);
            if (follow == null)
            {
                return NotFound();
            }
            return Ok(follow);
        }
        [HttpPost]
        public async Task<ActionResult<FollowDTO>> CreateFollow([FromBody] CreateFollowDTO follow)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdFollow = await _followService.CreateFollowAsync(follow);

            if (createdFollow == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetFollowById), new { id = createdFollow.Id }, createdFollow);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateFollow(int id, [FromBody] FollowDTO follow)
        {
            var result = await _followService.UpdateFollowAsync(id, follow);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFollow(int id)
        {
            var result = await _followService.DeleteFollowAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
