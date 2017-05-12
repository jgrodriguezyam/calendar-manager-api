using CalendarManager.DTO.Message.Locations;
using CalendarManager.DTO.Message.Users;

namespace CalendarManager.DTO.Message.SharedLocations
{
    public class SharedLocationResponse
    {
        public int Id { get; set; }
        public UserResponse User { get; set; }
        public LocationResponse Location { get; set; }
    }
}