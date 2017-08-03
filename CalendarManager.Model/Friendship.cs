using CalendarManager.Model.Base;

namespace CalendarManager.Model
{
    public class Friendship : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FriendId { get; set; }
        public virtual User Friend { get; set; }
        public bool IsConfirmed { get; set; }

        public bool IsActive { get; set; }
    }
}