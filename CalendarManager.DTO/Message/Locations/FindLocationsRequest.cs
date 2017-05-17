using CalendarManager.DTO.BaseRequest;

namespace CalendarManager.DTO.Message.Locations
{
    public class FindLocationsRequest : FindBaseRequest
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int UserId { get; set; }
        public bool OnlyToday { get; set; }
        public string Date { get; set; }
    }
}