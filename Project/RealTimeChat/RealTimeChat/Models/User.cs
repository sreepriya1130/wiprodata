using System;
using System.Collections.Generic;

namespace RealTimeChatApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Status { get; set; } = "Offline"; // Available, Busy, Offline
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
        public ICollection<ChatLog> ChatLogs { get; set; }
    }
}
