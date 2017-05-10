using System.Collections.Generic;
using CalendarManager.DTO.BaseResponse;

namespace CalendarManager.DTO.Message.Users
{
    public class FindUsersResponse : FindBaseResponse
    {
        public FindUsersResponse()
        {
            Users = new List<UserResponse>();
        }

        public List<UserResponse> Users { get; set; }
    }
}