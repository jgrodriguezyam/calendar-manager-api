using CalendarManager.Model.Base;
using CalendarManager.Model.Enums;

namespace CalendarManager.Model
{
    public class CheckIn : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public ECheckInType Type { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public bool IsActive { get; set; }
    }
}