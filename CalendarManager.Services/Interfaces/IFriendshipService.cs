using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.Friendships;

namespace CalendarManager.Services.Interfaces
{
    public interface IFriendshipService
    {
        FindFriendshipsResponse Find(FindFriendshipsRequest request);
        CreateResponse Create(FriendshipRequest request);
        FriendshipResponse Get(GetFriendshipRequest request);
        SuccessResponse Delete(DeleteFriendshipRequest request);
        SuccessResponse Confirm(ConfirmRequest request);
    }
}