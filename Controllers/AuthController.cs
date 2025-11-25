using Hyper_Radio_API.Data;
using Hyper_Radio_API.DTOs.AdminDTOs;
using Hyper_Radio_API.Models;
using Hyper_Radio_API.Services.TokenServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hyper_Radio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HyperRadioDbContext _context;
        private readonly ITokenService _tokenService;
        public AuthController(HyperRadioDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterAdminDTO newAdmin)
        {
            var existing = _context.Admins.FirstOrDefault(a => a.Email == newAdmin.Email);
            if (existing != null)
            {
                return BadRequest("Username already exists");
            }
            var password = BCrypt.Net.BCrypt.HashPassword(newAdmin.Password);
            var admin = new Admin
            {
                Email = newAdmin.Email,
                PasswordHash = password
            };
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return Ok("Admin registered");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginAdminDTO loginAdmin)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Email == loginAdmin.Email);
            if (admin == null)
            {
                return Unauthorized("Invalid username or password");
            }

            bool passwordMatching = BCrypt.Net.BCrypt.Verify(loginAdmin.Password, admin.PasswordHash);
            if (!passwordMatching)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _tokenService.GenerateToken(admin);


            return Ok(new { token });
        }

    }
}
