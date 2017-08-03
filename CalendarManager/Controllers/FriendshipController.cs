using System.Web.Http;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.Friendships;
using CalendarManager.Services.Interfaces;

namespace CalendarManager.Controllers
{
    public class FriendshipController : ApiController
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipController(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpGet, Route("friendships")]
        public FindFriendshipsResponse Get(FindFriendshipsRequest request)
        {
            return _friendshipService.Find(request);
        }

        [HttpPost, Route("friendships")]
        public CreateResponse Post(FriendshipRequest request)
        {
            return _friendshipService.Create(request);
        }

        [HttpGet, Route("friendships/{Id}")]
        public FriendshipResponse Get(GetFriendshipRequest request)
        {
            return _friendshipService.Get(request);
        }

        [HttpDelete, Route("friendships/{Id}")]
        public SuccessResponse Delete(DeleteFriendshipRequest request)
        {
            return _friendshipService.Delete(request);
        }

        [HttpPut, Route("friendships/confirm")]
        public SuccessResponse Put(ConfirmRequest request)
        {
            return _friendshipService.Confirm(request);
        }
    }
}