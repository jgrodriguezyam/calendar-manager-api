using CalendarManager.DTO.Message.Users;

namespace CalendarManager.DTO.Message.Locations
{
    public class LocationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public int Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Comment { get; set; }
        public UserResponse User { get; set; }
    }
}