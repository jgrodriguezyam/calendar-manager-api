using System.Collections.Generic;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.CheckIns;
using CalendarManager.Infrastructure.Collections;
using CalendarManager.Infrastructure.Exceptions;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Model;
using CalendarManager.Model.Enums;
using CalendarManager.Services.Interfaces;
using CalendarManager.Services.Validators.Interfaces;
using FastMapper;

namespace CalendarManager.Services.Implements
{
    public class CheckInService : ICheckInService
    {
        private readonly ICheckInQuery _checkInQuery;
        private readonly ICheckInRepository _checkInRepository;
        private readonly ICheckInValidator _checkInValidator;
        private readonly ILocationRepository _locationRepository;

        public CheckInService(ICheckInQuery checkInQuery, ICheckInRepository checkInRepository, ICheckInValidator checkInValidator, ILocationRepository locationRepository)
        {
            _checkInQuery = checkInQuery;
            _checkInRepository = checkInRepository;
            _checkInValidator = checkInValidator;
            _locationRepository = locationRepository;
        }

        public FindCheckInsResponse Find(FindCheckInsRequest request)
        {
            try
            {
                _checkInQuery.Init();
                _checkInQuery.WithOnlyActivated(true);
                _checkInQuery.WithType(request.Type.ConvertToEnum<ECheckInType>());
                _checkInQuery.WithUser(request.UserId);
                _checkInQuery.WithLocation(request.LocationId);
                _checkInQuery.IncludeUser();
                _checkInQuery.IncludeLocation();
                _checkInQuery.Sort(request.Sort, request.SortBy);
                var totalRecords = _checkInQuery.TotalRecords();
                _checkInQuery.Paginate(request.ItemsToShow, request.Page);
                var checkIns = _checkInQuery.Execute();

                return new FindCheckInsResponse
                {
                    CheckIns = TypeAdapter.Adapt<List<CheckInResponse>>(checkIns),
                    TotalRecords = totalRecords
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CreateResponse Create(CheckInRequest request)
        {
            try
            {
                var checkIn = TypeAdapter.Adapt<CheckIn>(request);
                _checkInValidator.ValidateAndThrowException(checkIn, "Base");
                var locations = _locationRepository.FindBy(currentLocation =>
                                                        currentLocation.UserId == checkIn.UserId &&
                                                        currentLocation.Id == checkIn.LocationId &&
                                                        currentLocation.IsActive);
                checkIn.Type = ECheckInType.Shared;
                if (locations.IsNotEmpty())
                    checkIn.Type = ECheckInType.Owner;
                _checkInRepository.Add(checkIn);
                return new CreateResponse(checkIn.Id);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CheckInResponse Get(GetCheckInRequest request)
        {
            try
            {
                _checkInQuery.Init();
                _checkInQuery.WithOnlyActivated(true);
                _checkInQuery.WithId(request.Id);
                _checkInQuery.IncludeUser();
                _checkInQuery.IncludeLocation();
                var checkIn = _checkInQuery.Execute().FirstOrDefault();
                checkIn.ThrowExceptionIfRecordIsNull();
                return TypeAdapter.Adapt<CheckIn, CheckInResponse>(checkIn);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Delete(DeleteCheckInRequest request)
        {
            try
            {
                var checkIn = _checkInRepository.FindBy(request.Id);
                checkIn.ThrowExceptionIfRecordIsNull();
                _checkInRepository.Remove(checkIn);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }
    }
}