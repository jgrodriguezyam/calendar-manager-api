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
    public class SharedLocationValidator : BaseValidator<SharedLocation>, ISharedLocationValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISharedLocationRepository _sharedLocationRepository;

        public SharedLocationValidator(IUserRepository userRepository, ILocationRepository locationRepository, ISharedLocationRepository sharedLocationRepository)
        {
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _sharedLocationRepository = sharedLocationRepository;

            RuleSet("Base", () =>
            {
                RuleFor(sharedLocation => sharedLocation.UserId).Must(userId => userId.IsNotZero()).WithMessage("Tienes que elegir un usuario");
                RuleFor(sharedLocation => sharedLocation.LocationId).Must(locationId => locationId.IsNotZero()).WithMessage("Tienes que elegir una ubicación");
                Custom(ReferencesValidate);
            });
        }

        public ValidationFailure ReferencesValidate(SharedLocation sharedLocation, ValidationContext<SharedLocation> context)
        {
            var user = _userRepository.FindBy(sharedLocation.UserId);
            if (user.IsNull())
                return new ValidationFailure("SharedLocation", "El usuario no existe");

            var location = _locationRepository.FindBy(sharedLocation.LocationId);
            if (location.IsNull())
                return new ValidationFailure("SharedLocation", "La ubicación no existe");

            var sharedLocations = _sharedLocationRepository.FindBy(currentSharedLocation => 
                                                                currentSharedLocation.UserId == sharedLocation.UserId &&
                                                                currentSharedLocation.LocationId == sharedLocation.LocationId &&
                                                                currentSharedLocation.IsActive);
            if (sharedLocations.IsNotEmpty())
                return new ValidationFailure("SharedLocation", "La ubicación ya esta compartida");

            var userLocation = _locationRepository.FindBy(currentLocation =>
                                                        currentLocation.Id == sharedLocation.LocationId &&
                                                        currentLocation.UserId == sharedLocation.UserId);
            if (userLocation.IsNotEmpty())
                return new ValidationFailure("SharedLocation", "La ubicación le pertence al usuario");

            return null;
        }
    }
}