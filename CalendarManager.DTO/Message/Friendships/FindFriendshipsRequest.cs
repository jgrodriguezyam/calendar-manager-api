using CalendarManager.DTO.BaseRequest;

namespace CalendarManager.DTO.Message.Friendships
{
    public class FindFriendshipsRequest : FindBaseRequest
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public bool OnlyConfirmed { get; set; }
        public bool OnlyUnconfirmed { get; set; }
    }
}