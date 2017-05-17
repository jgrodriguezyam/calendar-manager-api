using System;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.Infrastructure.Collections;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Infrastructure.Objects;
using CalendarManager.Infrastructure.Validators;
using CalendarManager.Model;
using CalendarManager.Services.Validators.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace CalendarManager.Services.Validators.Implements
{
    public class CheckInValidator : BaseValidator<CheckIn>, ICheckInValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISharedLocationRepository _sharedLocationRepository;
        private readonly ICheckInRepository _checkInRepository;

        public CheckInValidator(IUserRepository userRepository, ILocationRepository locationRepository, ISharedLocationRepository sharedLocationRepository, ICheckInRepository checkInRepository)
        {
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _sharedLocationRepository = sharedLocationRepository;
            _checkInRepository = checkInRepository;

            RuleSet("Base", () =>
            {
                RuleFor(sharedLocation => sharedLocation.UserId).Must(userId => userId.IsNotZero()).WithMessage("Tienes que elegir un usuario");
                RuleFor(sharedLocation => sharedLocation.LocationId).Must(locationId => locationId.IsNotZero()).WithMessage("Tienes que elegir una ubicación");
                Custom(ReferencesValidate);
            });
        }

        public ValidationFailure ReferencesValidate(CheckIn checkIn, ValidationContext<CheckIn> context)
        {
            var user = _userRepository.FindBy(checkIn.UserId);
            if (user.IsNull())
                return new ValidationFailure("CheckIn", "El usuario no existe");

            var location = _locationRepository.FindBy(checkIn.LocationId);
            if (location.IsNull())
                return new ValidationFailure("CheckIn", "La ubicación no existe");

            var sharedLocations = _sharedLocationRepository.FindBy(currentSharedLocation =>
                                                                currentSharedLocation.UserId == checkIn.UserId &&
                                                                currentSharedLocation.LocationId == checkIn.LocationId &&
                                                                currentSharedLocation.IsActive);

            var userLocations = _locationRepository.FindBy(currentLocation =>
                                                        currentLocation.UserId == checkIn.UserId &&
                                                        currentLocation.Id == checkIn.LocationId &&
                                                        currentLocation.IsActive);

            if (sharedLocations.IsEmpty() && userLocations.IsEmpty())
                return new ValidationFailure("CheckIn", "La ubicación no esta asignada al usuario");

            var today = DateTime.Now.Date;
            var checkIns = _checkInRepository.FindBy(currentCheckIn => 
                                currentCheckIn.UserId == checkIn.UserId &&
                                currentCheckIn.LocationId == checkIn.LocationId &&
                                currentCheckIn.CreatedOn.Year == today.Year &&
                                currentCheckIn.CreatedOn.Month == today.Month &&
                                currentCheckIn.CreatedOn.Day == today.Day && 
                                currentCheckIn.IsActive);

            if (checkIns.IsNotEmpty())
                return new ValidationFailure("CheckIn", "Ya te registraste hoy");

            return null;
        }
    }
}