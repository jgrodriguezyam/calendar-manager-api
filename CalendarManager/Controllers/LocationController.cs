using System.Web.Http;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.Locations;
using CalendarManager.Services.Interfaces;

namespace CalendarManager.Controllers
{
    public class LocationController : ApiController
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet, Route("locations")]
        public FindLocationsResponse Get(FindLocationsRequest request)
        {
            return _locationService.Find(request);
        }

        [HttpPost, Route("locations")]
        public CreateResponse Post(LocationRequest request)
        {
            return _locationService.Create(request);
        }

        [HttpPut, Route("locations")]
        public SuccessResponse Put(LocationRequest request)
        {
            return _locationService.Update(request);
        }

        [HttpGet, Route("locations/{Id}")]
        public LocationResponse Get(GetLocationRequest request)
        {
            return _locationService.Get(request);
        }

        [HttpDelete, Route("locations/{Id}")]
        public SuccessResponse Delete(DeleteLocationRequest request)
        {
            return _locationService.Delete(request);
        }
    }
}