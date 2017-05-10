namespace CalendarManager.DTO.BaseRequest
{
    public class FindStatusRequest : FindBaseRequest
    {
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}