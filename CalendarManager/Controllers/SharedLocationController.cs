using System.Web.Http;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.SharedLocations;
using CalendarManager.Services.Interfaces;

namespace CalendarManager.Controllers
{
    public class SharedLocationController : ApiController
    {
        private readonly ISharedLocationService _sharedLocationService;

        public SharedLocationController(ISharedLocationService sharedLocationService)
        {
            _sharedLocationService = sharedLocationService;
        }

        [HttpGet, Route("shared-locations")]
        public FindSharedLocationsResponse Get(FindSharedLocationsRequest request)
        {
            return _sharedLocationService.Find(request);
        }

        [HttpPost, Route("shared-locations")]
        public CreateResponse Post(SharedLocationRequest request)
        {
            return _sharedLocationService.Create(request);
        }

        [HttpGet, Route("shared-locations/{Id}")]
        public SharedLocationResponse Get(GetSharedLocationRequest request)
        {
            return _sharedLocationService.Get(request);
        }

        [HttpDelete, Route("shared-locations/{Id}")]
        public SuccessResponse Delete(DeleteSharedLocationRequest request)
        {
            return _sharedLocationService.Delete(request);
        }
    }
}