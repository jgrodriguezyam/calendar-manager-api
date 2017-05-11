using CalendarManager.Model.Base;

namespace CalendarManager.Model
{
    public class SharedLocation : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public bool IsActive { get; set; }
    }
}
