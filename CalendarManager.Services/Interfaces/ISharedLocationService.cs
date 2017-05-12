using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.SharedLocations;

namespace CalendarManager.Services.Interfaces
{
    public interface ISharedLocationService
    {
        FindSharedLocationsResponse Find(FindSharedLocationsRequest request);
        CreateResponse Create(SharedLocationRequest request);
        SharedLocationResponse Get(GetSharedLocationRequest request);
        SuccessResponse Delete(DeleteSharedLocationRequest request);
    }
}