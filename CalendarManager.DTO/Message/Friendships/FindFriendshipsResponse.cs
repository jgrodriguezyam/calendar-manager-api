using System.Collections.Generic;
using CalendarManager.DTO.BaseResponse;

namespace CalendarManager.DTO.Message.Friendships
{
    public class FindFriendshipsResponse : FindBaseResponse
    {
        public FindFriendshipsResponse()
        {
            Friendships = new List<FriendshipResponse>();
        }

        public List<FriendshipResponse> Friendships { get; set; }
    }
}