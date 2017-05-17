using System.Collections.Generic;
using CalendarManager.DTO.BaseResponse;

namespace CalendarManager.DTO.Message.CheckIns
{
    public class FindCheckInsResponse : FindBaseResponse
    {
        public FindCheckInsResponse()
        {
            CheckIns = new List<CheckInResponse>();
        }

        public List<CheckInResponse> CheckIns { get; set; }
    }
}