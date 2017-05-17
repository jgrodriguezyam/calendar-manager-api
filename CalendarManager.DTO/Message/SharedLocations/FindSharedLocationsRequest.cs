using CalendarManager.DTO.BaseRequest;

namespace CalendarManager.DTO.Message.SharedLocations
{
    public class FindSharedLocationsRequest : FindBaseRequest
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public bool LocationOnlyToday { get; set; }
        public string LocationDate { get; set; }
    }
}