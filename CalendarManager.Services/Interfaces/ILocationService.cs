using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.Locations;

namespace CalendarManager.Services.Interfaces
{
    public interface ILocationService
    {
        FindLocationsResponse Find(FindLocationsRequest request);
        CreateResponse Create(LocationRequest request);
        SuccessResponse Update(LocationRequest request);
        LocationResponse Get(GetLocationRequest request);
        SuccessResponse Delete(DeleteLocationRequest request);
    }
}