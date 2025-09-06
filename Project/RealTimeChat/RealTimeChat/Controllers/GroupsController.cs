using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealTimeChatApp.Models;

namespace RealTimeChatApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private readonly ChatDbContext _db;

        public GroupsController(ChatDbContext db)
        {
            _db = db;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGroup([FromBody] string groupName)
        {
            var userId = int.Parse(User.Identity!.Name);

            var group = new Group
            {
                GroupName = groupName,
                CreatedBy = userId
            };
            _db.Groups.Add(group);
            await _db.SaveChangesAsync();

            _db.GroupMembers.Add(new GroupMember
            {
                GroupId = group.GroupId,
                UserId = userId
            });
            await _db.SaveChangesAsync();

            return Ok(group);
        }

        [HttpPost("addMember")]
        public async Task<IActionResult> AddMember(int groupId, int userId)
        {
            if (!_db.Groups.Any(g => g.GroupId == groupId))
                return NotFound("Group not found");

            _db.GroupMembers.Add(new GroupMember
            {
                GroupId = groupId,
                UserId = userId
            });
            await _db.SaveChangesAsync();

            return Ok("User added to group");
        }

        [HttpGet("{groupId}/members")]
        public async Task<IActionResult> GetMembers(int groupId)
        {
            var members = await _db.GroupMembers
                .Include(gm => gm.User)
                .Where(gm => gm.GroupId == groupId)
                .Select(gm => gm.User)
                .ToListAsync();

            return Ok(members);
        }
    }
}
