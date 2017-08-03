using CalendarManager.Model;

namespace CalendarManager.DataAccess.Queries
{
    public interface IFriendshipQuery : IQuery<Friendship>
    {
        void WithId(int id);
        void WithOnlyActivated(bool onlyActivated);
        void WithUser(int userId);
        void WithFriend(int friendId);
        void WithOnlyConfirmed(bool onlyConfirmed);
        void WithOnlyUnconfirmed(bool onlyUnconfirmed);
        void WithUserOrFriend(int userIdOrFriendId);
        void IncludeUser();
        void IncludeFriend();
    }
}