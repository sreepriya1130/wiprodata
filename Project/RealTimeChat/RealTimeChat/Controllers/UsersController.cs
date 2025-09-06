using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealTimeChatApp.Models;
using System.Threading.Tasks;

namespace RealTimeChatApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ChatDbContext _context;

        public UsersController(ChatDbContext context)
        {
            _context = context;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetUserStatuses()
        {
            var users = await _context.Users
                .Select(u => new { u.Username, u.Status })
                .ToListAsync();

            return Ok(users);
        }

        [HttpPut("update-status/{userId}")]
        public async Task<IActionResult> UpdateStatus(int userId, [FromBody] string newStatus)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return NotFound("User not found");

            user.Status = newStatus;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Status updated successfully!" });
        }
    }
}
