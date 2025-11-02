using Hyper_Radio_API.DTOs.AdminDTOs;
using Hyper_Radio_API.Services.AdminServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AdminDTO?>> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }
        [HttpPost]
        public async Task<ActionResult<AdminDTO>> CreateAdmin([FromBody] CreateAdminDTO admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAdmin = await _adminService.CreateAdminAsync(admin);

            if (createdAdmin == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetAdminById), new { id = createdAdmin.Id }, createdAdmin);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] AdminDTO admin)
        {
            var result = await _adminService.UpdateAdminAsync(id, admin);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var result = await _adminService.DeleteAdminAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
