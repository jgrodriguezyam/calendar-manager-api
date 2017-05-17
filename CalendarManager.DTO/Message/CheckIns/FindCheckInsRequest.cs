using CalendarManager.DTO.BaseRequest;

namespace CalendarManager.DTO.Message.CheckIns
{
    public class FindCheckInsRequest : FindBaseRequest
    {
        public int Type { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
    }
}