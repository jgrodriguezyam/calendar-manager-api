using CalendarManager.DTO.Message.Users;

namespace CalendarManager.DTO.Message.Friendships
{
    public class FriendshipResponse
    {
        public int Id { get; set; }
        public virtual UserResponse User { get; set; }
        public virtual UserResponse Friend { get; set; }
        public bool IsConfirmed { get; set; }
    }
}