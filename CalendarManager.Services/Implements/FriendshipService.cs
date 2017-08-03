using System.Collections.Generic;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.Friendships;
using CalendarManager.Infrastructure.Exceptions;
using CalendarManager.Model;
using CalendarManager.Services.Interfaces;
using CalendarManager.Services.Validators.Interfaces;
using FastMapper;

namespace CalendarManager.Services.Implements
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipQuery _friendshipQuery;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IFriendshipValidator _friendshipValidator;

        public FriendshipService(IFriendshipQuery friendshipQuery, IFriendshipRepository friendshipRepository, IFriendshipValidator friendshipValidator)
        {
            _friendshipQuery = friendshipQuery;
            _friendshipRepository = friendshipRepository;
            _friendshipValidator = friendshipValidator;
        }

        public FindFriendshipsResponse Find(FindFriendshipsRequest request)
        {
            try
            {
                _friendshipQuery.Init();
                _friendshipQuery.WithOnlyActivated(true);
                _friendshipQuery.WithUser(request.UserId);
                _friendshipQuery.WithFriend(request.FriendId);
                _friendshipQuery.WithOnlyConfirmed(request.OnlyConfirmed);
                _friendshipQuery.WithOnlyUnconfirmed(request.OnlyUnconfirmed);
                _friendshipQuery.WithUserOrFriend(request.UserIdOrFriendId);
                _friendshipQuery.IncludeUser();
                _friendshipQuery.IncludeFriend();
                _friendshipQuery.Sort(request.Sort, request.SortBy);
                var totalRecords = _friendshipQuery.TotalRecords();
                _friendshipQuery.Paginate(request.ItemsToShow, request.Page);
                var friendships = _friendshipQuery.Execute();

                return new FindFriendshipsResponse
                {
                    Friendships = TypeAdapter.Adapt<List<FriendshipResponse>>(friendships),
                    TotalRecords = totalRecords
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CreateResponse Create(FriendshipRequest request)
        {
            try
            {
                var friendship = TypeAdapter.Adapt<Friendship>(request);
                _friendshipValidator.ValidateAndThrowException(friendship, "Base");
                _friendshipRepository.Add(friendship);
                return new CreateResponse(friendship.Id);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public FriendshipResponse Get(GetFriendshipRequest request)
        {
            try
            {
                request.Id.ThrowExceptionIfIsZero();
                _friendshipQuery.Init();
                _friendshipQuery.WithOnlyActivated(true);
                _friendshipQuery.WithId(request.Id);
                _friendshipQuery.IncludeUser();
                _friendshipQuery.IncludeFriend();
                var friendship = _friendshipQuery.Execute().FirstOrDefault();
                friendship.ThrowExceptionIfRecordIsNull();
                return TypeAdapter.Adapt<Friendship, FriendshipResponse>(friendship);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Delete(DeleteFriendshipRequest request)
        {
            try
            {
                var friendship = _friendshipRepository.FindBy(request.Id);
                friendship.ThrowExceptionIfRecordIsNull();
                _friendshipRepository.Remove(friendship);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Confirm(ConfirmRequest request)
        {
            try
            {
                var friendship = _friendshipRepository.FindBy(request.Id);
                friendship.ThrowExceptionIfRecordIsNull();
                friendship.IsConfirmed = true;
                _friendshipRepository.Update(friendship);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }
    }
}