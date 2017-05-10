using CalendarManager.DTO.BaseResponse;

namespace CalendarManager.DTO.Message.Users
{
    public class LoginUserResponse : LoginResponse
    {
        public int UserId { get; set; }
    }
}