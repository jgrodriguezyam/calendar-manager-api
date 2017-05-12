using System.Collections.Generic;
using System.Linq;
using FastMapper;
using CalendarManager.DataAccess.Queries;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.Locations;
using CalendarManager.Infrastructure.Exceptions;
using CalendarManager.Model;
using CalendarManager.Services.Interfaces;
using CalendarManager.Services.Validators.Interfaces;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Model.Enums;

namespace CalendarManager.Services.Implements
{
    public class LocationService : ILocationService
    {
        private readonly ILocationQuery _locationQuery;
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationValidator _locationValidator;

        public LocationService(ILocationQuery locationQuery, ILocationRepository locationRepository, ILocationValidator locationValidator)
        {
            _locationQuery = locationQuery;
            _locationRepository = locationRepository;
            _locationValidator = locationValidator;
        }

        public FindLocationsResponse Find(FindLocationsRequest request)
        {
            try
            {
                _locationQuery.Init();
                _locationQuery.WithOnlyActivated(true);
                _locationQuery.WithName(request.Name);
                _locationQuery.WithType(request.Type.ConvertToEnum<ELocationType>());
                _locationQuery.WithUser(request.UserId);
                _locationQuery.IncludeUser();
                _locationQuery.Sort(request.Sort, request.SortBy);
                var totalRecords = _locationQuery.TotalRecords();
                _locationQuery.Paginate(request.ItemsToShow, request.Page);
                var locations = _locationQuery.Execute();

                return new FindLocationsResponse
                {
                    Locations = TypeAdapter.Adapt<List<LocationResponse>>(locations),
                    TotalRecords = totalRecords
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CreateResponse Create(LocationRequest request)
        {
            try
            {
                var location = TypeAdapter.Adapt<Location>(request);
                _locationValidator.ValidateAndThrowException(location, "Base");
                _locationRepository.Add(location);
                return new CreateResponse(location.Id);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Update(LocationRequest request)
        {
            try
            {
                var currentLocation = _locationRepository.FindBy(request.Id);
                currentLocation.ThrowExceptionIfRecordIsNull();
                var locationToCopy = TypeAdapter.Adapt<Location>(request);
                TypeAdapter.Adapt(locationToCopy, currentLocation);
                _locationValidator.ValidateAndThrowException(currentLocation, "Base");
                _locationRepository.Update(currentLocation);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public LocationResponse Get(GetLocationRequest request)
        {
            try
            {
                _locationQuery.Init();
                _locationQuery.WithOnlyActivated(true);
                _locationQuery.WithId(request.Id);
                _locationQuery.IncludeUser();
                var location = _locationQuery.Execute().FirstOrDefault();
                location.ThrowExceptionIfRecordIsNull();
                return TypeAdapter.Adapt<Location, LocationResponse>(location);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Delete(DeleteLocationRequest request)
        {
            try
            {
                var location = _locationRepository.FindBy(request.Id);
                location.ThrowExceptionIfRecordIsNull();
                _locationRepository.Remove(location);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }
    }
}