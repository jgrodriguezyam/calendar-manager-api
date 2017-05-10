using System.Collections.Generic;
using CalendarManager.DTO.BaseResponse;

namespace CalendarManager.DTO.Message.Locations
{
    public class FindLocationsResponse : FindBaseResponse
    {
        public FindLocationsResponse()
        {
            Locations = new List<LocationResponse>();
        }

        public List<LocationResponse> Locations { get; set; }
    }
}