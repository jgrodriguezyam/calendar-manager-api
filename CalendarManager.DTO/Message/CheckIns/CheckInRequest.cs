namespace CalendarManager.DTO.Message.CheckIns
{
    public class CheckInRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
    }
}