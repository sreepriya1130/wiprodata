using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealTimeChatApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace RealTimeChatApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ChatDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(ChatDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // ✅ Register new user
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email already registered.");

            var user = new User
            {
                Username = dto.Email,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                PasswordHash = HashPassword(dto.Password),
                Status = "Available"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registered successfully" });
        }

        // ✅ Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return Unauthorized("Invalid email or password");

            if (user.PasswordHash != HashPassword(dto.Password))
                return Unauthorized("Invalid email or password");

            return Ok(new
            {
                token = CreateToken(user),
                user = new
                {
                    user.UserId,
                    user.Email,
                    user.DisplayName,
                    user.Status
                }
            });
        }

        // ✅ Logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == dto.Id);
            if (user == null)
                return NotFound("User not found.");

            // Optionally mark user as offline
            user.Status = "Offline";
            //user.LastSeenUtc = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new { message = $"{user.DisplayName} you are logged out" });
        }


        // ✅ JWT creation
        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim("DisplayName", user.DisplayName ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwt = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ✅ SHA256 password hashing
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        // ✅ DTOs
        public record RegisterDto(string Email, string Password, string DisplayName);
        public record LoginDto(string Email, string Password);
        public record LogoutDto(int Id);
    }
}
