using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.CheckIns;

namespace CalendarManager.Services.Interfaces
{
    public interface ICheckInService
    {
        FindCheckInsResponse Find(FindCheckInsRequest request);
        CreateResponse Create(CheckInRequest request);
        CheckInResponse Get(GetCheckInRequest request);
        SuccessResponse Delete(DeleteCheckInRequest request);
    }
}