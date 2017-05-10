using CalendarManager.DTO.BaseRequest;

namespace CalendarManager.DTO.Message.Users
{
    public class FindUsersRequest : FindBaseRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderType { get; set; }
        public string Email { get; set; }
        public long CellNumber { get; set; }
        public string UserName { get; set; }
        public string Device { get; set; }
    }
}