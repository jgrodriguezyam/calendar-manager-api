using System.Collections.Generic;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.SharedLocations;
using CalendarManager.Infrastructure.Exceptions;
using CalendarManager.Model;
using CalendarManager.Services.Interfaces;
using CalendarManager.Services.Validators.Interfaces;
using FastMapper;

namespace CalendarManager.Services.Implements
{
    public class SharedLocationService : ISharedLocationService
    {
        private readonly ISharedLocationQuery _sharedLocationQuery;
        private readonly ISharedLocationRepository _sharedLocationRepository;
        private readonly ISharedLocationValidator _sharedLocationValidator;

        public SharedLocationService(ISharedLocationQuery sharedLocationQuery, ISharedLocationRepository sharedLocationRepository, ISharedLocationValidator sharedLocationValidator)
        {
            _sharedLocationQuery = sharedLocationQuery;
            _sharedLocationRepository = sharedLocationRepository;
            _sharedLocationValidator = sharedLocationValidator;
        }

        public FindSharedLocationsResponse Find(FindSharedLocationsRequest request)
        {
            try
            {
                _sharedLocationQuery.Init();
                _sharedLocationQuery.WithOnlyActivated(true);
                _sharedLocationQuery.WithUser(request.UserId);
                _sharedLocationQuery.WithLocation(request.LocationId);
                _sharedLocationQuery.WithLocationOnlyToday(request.LocationOnlyToday);
                _sharedLocationQuery.WithLocationDate(request.LocationDate);
                _sharedLocationQuery.IncludeUser();
                _sharedLocationQuery.IncludeLocation();
                _sharedLocationQuery.Sort(request.Sort, request.SortBy);
                var totalRecords = _sharedLocationQuery.TotalRecords();
                _sharedLocationQuery.Paginate(request.ItemsToShow, request.Page);
                var sharedLocations = _sharedLocationQuery.Execute();

                return new FindSharedLocationsResponse
                {
                    SharedLocations = TypeAdapter.Adapt<List<SharedLocationResponse>>(sharedLocations),
                    TotalRecords = totalRecords
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CreateResponse Create(SharedLocationRequest request)
        {
            try
            {
                var sharedLocation = TypeAdapter.Adapt<SharedLocation>(request);
                _sharedLocationValidator.ValidateAndThrowException(sharedLocation, "Base");
                _sharedLocationRepository.Add(sharedLocation);
                return new CreateResponse(sharedLocation.Id);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SharedLocationResponse Get(GetSharedLocationRequest request)
        {
            try
            {
                request.Id.ThrowExceptionIfIsZero();
                _sharedLocationQuery.Init();
                _sharedLocationQuery.WithOnlyActivated(true);
                _sharedLocationQuery.WithId(request.Id);
                _sharedLocationQuery.IncludeUser();
                _sharedLocationQuery.IncludeLocation();
                var sharedLocation = _sharedLocationQuery.Execute().FirstOrDefault();
                sharedLocation.ThrowExceptionIfRecordIsNull();
                return TypeAdapter.Adapt<SharedLocation, SharedLocationResponse>(sharedLocation);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Delete(DeleteSharedLocationRequest request)
        {
            try
            {
                var sharedLocation = _sharedLocationRepository.FindBy(request.Id);
                sharedLocation.ThrowExceptionIfRecordIsNull();
                _sharedLocationRepository.Remove(sharedLocation);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }
    }
}