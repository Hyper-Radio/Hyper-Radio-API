using Hyper_Radio_API.DTOs.FavoriteDTOs;
using Hyper_Radio_API.Services.FavoriteServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteDTO>>> GetAllFavorites()
        {
            var favorites = await _favoriteService.GetAllFavoritesAsync();
            return Ok(favorites);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FavoriteDTO?>> GetFavoriteById(int id)
        {
            var favorite = await _favoriteService.GetFavoriteByIdAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            return Ok(favorite);
        }
        [HttpPost]
        public async Task<ActionResult<FavoriteDTO>> CreateFavorite([FromBody] CreateFavoriteDTO favorite)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdFavorite = await _favoriteService.CreateFavoriteAsync(favorite);

            if (createdFavorite == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetFavoriteById), new { id = createdFavorite.Id }, createdFavorite);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateFavorite(int id, [FromBody] FavoriteDTO favorite)
        {
            var result = await _favoriteService.UpdateFavoriteAsync(id, favorite);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var result = await _favoriteService.DeleteFavoriteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
