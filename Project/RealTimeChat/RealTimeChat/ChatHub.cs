using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using RealTimeChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChatApp.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ChatDbContext _db;

        public ChatHub(ChatDbContext db)
        {
            _db = db;
        }

        // ✅ Join a group (SignalR group = chat group)
        public async Task JoinGroup(int groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Group_{groupId}");
        }

        // ✅ Leave group
        public async Task LeaveGroup(int groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Group_{groupId}");
        }

        // ✅ Send message to group
        public async Task SendGroupMessage(int groupId, string messageText, string? fileUrl = null)
        {
            var userId = int.Parse(Context.UserIdentifier!);

            var message = new Message
            {
                SenderId = userId,
                GroupId = groupId,
                MessageText = messageText,
                FileUrl = fileUrl,
                SentAt = DateTime.UtcNow
            };

            _db.Messages.Add(message);
            await _db.SaveChangesAsync();

            var savedMessage = await _db.Messages
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.MessageId == message.MessageId);

            // broadcast to group members
            await Clients.Group($"Group_{groupId}").SendAsync("ReceiveMessage", savedMessage);
        }

        // ✅ Private message
        public async Task SendPrivateMessage(int receiverId, string messageText, string? fileUrl = null)
        {
            var userId = int.Parse(Context.UserIdentifier!);

            var message = new Message
            {
                SenderId = userId,
                ReceiverId = receiverId,
                MessageText = messageText,
                FileUrl = fileUrl,
                SentAt = DateTime.UtcNow
            };

            _db.Messages.Add(message);
            await _db.SaveChangesAsync();

            var savedMessage = await _db.Messages
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.MessageId == message.MessageId);

            // notify both sender & receiver
            await Clients.User(userId.ToString()).SendAsync("ReceiveMessage", savedMessage);
            await Clients.User(receiverId.ToString()).SendAsync("ReceiveMessage", savedMessage);
        }
    }
}
