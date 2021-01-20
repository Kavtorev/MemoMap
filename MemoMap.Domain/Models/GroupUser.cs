using MemoMap.Domain.SeedWork;

namespace MemoMap.Domain.Models
{
    public class GroupUser : Entity
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsNotAdmin { get => !IsAdmin; }
    }
}
