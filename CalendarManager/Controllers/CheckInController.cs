using System.Web.Http;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.CheckIns;
using CalendarManager.Services.Interfaces;

namespace CalendarManager.Controllers
{
    public class CheckInController : ApiController
    {
        private readonly ICheckInService _checkInService;

        public CheckInController(ICheckInService checkInService)
        {
            _checkInService = checkInService;
        }

        [HttpGet, Route("checkins")]
        public FindCheckInsResponse Get(FindCheckInsRequest request)
        {
            return _checkInService.Find(request);
        }

        [HttpPost, Route("checkins")]
        public CreateResponse Post(CheckInRequest request)
        {
            return _checkInService.Create(request);
        }

        [HttpGet, Route("checkins/{Id}")]
        public CheckInResponse Get(GetCheckInRequest request)
        {
            return _checkInService.Get(request);
        }

        [HttpDelete, Route("checkins/{Id}")]
        public SuccessResponse Delete(DeleteCheckInRequest request)
        {
            return _checkInService.Delete(request);
        }
    }
}