using CalendarManager.DTO.Message.Locations;
using CalendarManager.DTO.Message.Users;

namespace CalendarManager.DTO.Message.CheckIns
{
    public class CheckInResponse
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public UserResponse User { get; set; }
        public LocationResponse Location { get; set; }
    }
}