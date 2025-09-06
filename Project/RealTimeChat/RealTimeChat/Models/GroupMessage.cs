using System;
using System.ComponentModel.DataAnnotations;

namespace RealTimeChatApp.Models
{
    public class GroupMessage
    {
        [Key]
        public int Id { get; set; }

        // FK to group
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        // Sender and optional receiver (for direct messages)
        public int SenderId { get; set; }
        public User? Sender { get; set; }

        public int? ReceiverId { get; set; }
        public User? Receiver { get; set; }

        public string Message { get; set; } = string.Empty;
        public string? FilePath { get; set; }

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
