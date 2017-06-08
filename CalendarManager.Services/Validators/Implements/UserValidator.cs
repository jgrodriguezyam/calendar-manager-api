using System.Linq;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.Infrastructure.Collections;
using CalendarManager.Infrastructure.Enums;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Infrastructure.Objects;
using CalendarManager.Infrastructure.Validators;
using CalendarManager.Model;
using CalendarManager.Model.Enums;
using CalendarManager.Services.Validators.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace CalendarManager.Services.Validators.Implements
{
    public class UserValidator : BaseValidator<User>, IUserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleSet("Base", () =>
            {
                RuleFor(user => user.FirstName).NotNull().NotEmpty();
                RuleFor(user => user.LastName).NotNull().NotEmpty();
                RuleFor(user => user.GenderType).Must(genderType => genderType.GetValue().IsNotZero()).WithMessage("Tienes que elegir un genero");
                RuleFor(user => user.Email).NotNull().NotEmpty();
                RuleFor(user => user.CellNumber).Must(cellNumber => cellNumber.IsNotZero()).WithMessage("Captura tu número telefónico");
                RuleFor(user => user.UserName).NotNull().NotEmpty();
                RuleFor(user => user.Password).NotNull().NotEmpty();
                RuleFor(user => user.Badge).NotNull().NotEmpty();
                Custom(ReferencesValidate);
            });

            RuleSet("LoginValidate", () =>
            {
                Custom(LoginValidate);
            });

            RuleSet("Create", () =>
            {
                Custom(CreateValidate);
            });

            RuleSet("Update", () =>
            {
                Custom(UpdateValidate);
            });
        }

        public ValidationFailure ReferencesValidate(User user, ValidationContext<User> context)
        {
            var genderType = new EGenderType().ConvertToCollection().FirstOrDefault(genderTp => genderTp.Value == user.GenderType.GetValue());
            if (genderType.IsNull())
                return new ValidationFailure("User", "El tipo de genero no existe");

            return null;
        }

        public ValidationFailure LoginValidate(User user, ValidationContext<User> context)
        {
            var currentUser = _userRepository.FindBy(user.Id);
            if (currentUser.IsNull())
                return new ValidationFailure("User", "El usuario no existe");

            return null;
        }

        public ValidationFailure CreateValidate(User user, ValidationContext<User> context)
        {
            var usersByEmail = _userRepository.FindBy(currentUser => currentUser.Email == user.Email && currentUser.IsActive);
            if (usersByEmail.IsNotEmpty())
                return new ValidationFailure("User", "Ya existe el correo registrado");

            var usersByCellNumber = _userRepository.FindBy(currentUser => currentUser.CellNumber == user.CellNumber && currentUser.IsActive);
            if (usersByCellNumber.IsNotEmpty())
                return new ValidationFailure("User", "Ya existe el telefono registrado");

            var usersByUserName = _userRepository.FindBy(currentUser => currentUser.UserName == user.UserName && currentUser.IsActive);
            if (usersByUserName.IsNotEmpty())
                return new ValidationFailure("User", "Ya existe el nombre de usuario");

            return null;
        }

        public ValidationFailure UpdateValidate(User user, ValidationContext<User> context)
        {
            var usersByEmail = _userRepository.FindBy(currentUser => currentUser.Email == user.Email && currentUser.Id != user.Id && currentUser.IsActive);
            if (usersByEmail.IsNotEmpty())
                return new ValidationFailure("User", "Ya existe el correo registrado");

            var usersByCellNumber = _userRepository.FindBy(currentUser => currentUser.CellNumber == user.CellNumber && currentUser.Id != user.Id && currentUser.IsActive);
            if (usersByCellNumber.IsNotEmpty())
                return new ValidationFailure("User", "Ya existe el telefono registrado");

            var usersByUserName = _userRepository.FindBy(currentUser => currentUser.UserName == user.UserName && currentUser.Id != user.Id && currentUser.IsActive);
            if (usersByUserName.IsNotEmpty())
                return new ValidationFailure("User", "Ya existe el nombre de usuario");

            return null;
        }
    }
}