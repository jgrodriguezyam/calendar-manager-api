using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.Users;
using CalendarManager.Infrastructure.Files;

namespace CalendarManager.Services.Interfaces
{
    public interface IUserService
    {
        FindUsersResponse Find(FindUsersRequest request);
        CreateResponse Create(UserRequest request);
        SuccessResponse Update(UserRequest request);
        UserResponse Get(GetUserRequest request);
        SuccessResponse Delete(DeleteUserRequest request);
        LoginUserResponse Login(LoginUserRequest request);
        SuccessResponse Logout(LogoutUserRequest request);
        SuccessResponse ChangePassword(ChangeUserPasswordRequest request);
        AddImageUserResponse AddImage(AddImageUserRequest request, File file);
    }
}