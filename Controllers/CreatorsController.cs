using Hyper_Radio_API.DTOs.CreatorDTOs;
using Hyper_Radio_API.Services.CreatorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorsController : ControllerBase
    {
        private readonly ICreatorService _creatorService;
        public CreatorsController(ICreatorService creatorService)
        {
            _creatorService = creatorService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatorDTO>>> GetAllCreators()
        {
            var creators = await _creatorService.GetAllCreatorsAsync();
            return Ok(creators);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CreatorDTO?>> GetCreatorById(int id)
        {
            var creator = await _creatorService.GetCreatorByIdAsync(id);
            if (creator == null)
            {
                return NotFound();
            }
            return Ok(creator);
        }
        [HttpPost]
        public async Task<ActionResult<CreatorDTO>> CreateCreator([FromBody] CreateCreatorDTO creator)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCreator = await _creatorService.CreateCreatorAsync(creator);

            if (createdCreator == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetCreatorById), new { id = createdCreator.Id }, createdCreator);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCreator(int id, [FromBody] CreatorDTO creator)
        {
            var result = await _creatorService.UpdateCreatorAsync(id, creator);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCreator(int id)
        {
            var result = await _creatorService.DeleteCreatorAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
