using System.Collections.Generic;
using CalendarManager.DTO.BaseResponse;

namespace CalendarManager.DTO.Message.SharedLocations
{
    public class FindSharedLocationsResponse : FindBaseResponse
    {
        public FindSharedLocationsResponse()
        {
            SharedLocations = new List<SharedLocationResponse>();
        }

        public List<SharedLocationResponse> SharedLocations { get; set; }
    }
}