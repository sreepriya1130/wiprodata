using System;
using System.ComponentModel.DataAnnotations; // ✅ Needed for [Key]

namespace RealTimeChatApp.Models
{
    public class ChatLog
    {
        [Key] // ✅ Explicitly define primary key
        public int LogId { get; set; }

        public int UserId { get; set; }
        public string Action { get; set; } = string.Empty; // e.g., LOGIN, SEND_MESSAGE
        public string Description { get; set; } = string.Empty;
        public DateTime LoggedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public User User { get; set; }
    }
}
