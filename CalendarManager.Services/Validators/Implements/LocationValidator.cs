using System.Linq;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.Infrastructure.Validators;
using CalendarManager.Model;
using CalendarManager.Services.Validators.Interfaces;
using FluentValidation;
using CalendarManager.Infrastructure.Doubles;
using CalendarManager.Infrastructure.Enums;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Infrastructure.Objects;
using CalendarManager.Model.Enums;
using FluentValidation.Results;


namespace CalendarManager.Services.Validators.Implements
{
    public class LocationValidator : BaseValidator<Location>, ILocationValidator
    {
        private readonly IUserRepository _userRepository;

        public LocationValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleSet("Base", () =>
            {
                RuleFor(location => location.Name).NotNull().NotEmpty();
                RuleFor(location => location.Latitude).Must(latitude => latitude.IsNotZero()).WithMessage("Tienes que elegir una latitud");
                RuleFor(location => location.Longitude).Must(longitude => longitude.IsNotZero()).WithMessage("Tienes que elegir una longitud");
                RuleFor(location => location.Type).Must(type => type.GetValue().IsNotZero()).WithMessage("Tienes que elegir un tipo");
                Custom(ReferencesValidate);
            });
        }

        public ValidationFailure ReferencesValidate(Location location, ValidationContext<Location> context)
        {
            var locationType = new ELocationType().ConvertToCollection().FirstOrDefault(locationTp => locationTp.Value == location.Type.GetValue());
            if (locationType.IsNull())
                return new ValidationFailure("Location", "El tipo de ubicación no existe");

            var user = _userRepository.FindBy(location.UserId);
            if (user.IsNull())
                return new ValidationFailure("Location", "El usuario no existe");

            return null;
        }
    }
}