namespace CalendarManager.Model
{
    public class UserLocation
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
