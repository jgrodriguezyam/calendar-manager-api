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
    public class FriendshipValidator : BaseValidator<Friendship>, IFriendshipValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendshipRepository _friendshipRepository;

        public FriendshipValidator(IUserRepository userRepository, IFriendshipRepository friendshipRepository)
        {
            _userRepository = userRepository;
            _friendshipRepository = friendshipRepository;

            RuleSet("Base", () =>
            {
                RuleFor(friendship => friendship.UserId).Must(userId => userId.IsNotZero()).WithMessage("Tienes que elegir un usuario");
                RuleFor(friendship => friendship.FriendId).Must(friendId => friendId.IsNotZero()).WithMessage("Tienes que elegir un amigo");
                Custom(ReferencesValidate);
            });
        }

        public ValidationFailure ReferencesValidate(Friendship friendship, ValidationContext<Friendship> context)
        {
            var userAndFriendAreSame = friendship.UserId == friendship.FriendId;
            if (userAndFriendAreSame)
                return new ValidationFailure("Friendship", "El usuario y el amigo son iguales");

            var user = _userRepository.FindBy(friendship.UserId);
            if (user.IsNull())
                return new ValidationFailure("Friendship", "El usuario no existe");

            var friend = _userRepository.FindBy(friendship.FriendId);
            if (friend.IsNull())
                return new ValidationFailure("Friendship", "El amigo no existe");

            var friendshipsOfUser = _friendshipRepository.FindBy(currentFriendship =>
                                                                currentFriendship.UserId == friendship.UserId &&
                                                                currentFriendship.FriendId == friendship.FriendId &&
                                                                currentFriendship.IsActive);
            var friendshipsOfFriend = _friendshipRepository.FindBy(currentFriendship =>
                                                                currentFriendship.UserId == friendship.FriendId &&
                                                                currentFriendship.FriendId == friendship.UserId &&
                                                                currentFriendship.IsActive);

            if (friendshipsOfUser.IsNotEmpty() || friendshipsOfFriend.IsNotEmpty())
                return new ValidationFailure("Friendship", "Ya esta agregado tu amigo");

            return null;
        }
    }
}