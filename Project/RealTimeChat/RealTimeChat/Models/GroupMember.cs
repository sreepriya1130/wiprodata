using System.ComponentModel.DataAnnotations;

namespace RealTimeChatApp.Models
{
    public class GroupMember
    {
        [Key]
        public int Id { get; set; }

        // FK to group
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        // FK to user (int to avoid int->string conversions)
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
