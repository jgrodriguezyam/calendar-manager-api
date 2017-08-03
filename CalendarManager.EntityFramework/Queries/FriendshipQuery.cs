using System.Data.Entity;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.Queries
{
    public class FriendshipQuery : QueryBase<Friendship>, IFriendshipQuery
    {
        public FriendshipQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework) 
            : base(dataBaseSqlServerEntityFramework)
        {
        }

        public void WithId(int id)
        {
            if (id.IsNotZero())
                Query = Query.Where(friendship => friendship.Id == id);
        }

        public void WithOnlyActivated(bool onlyActivated)
        {
            if (onlyActivated)
                Query = Query.Where(friendship => friendship.IsActive);
        }

        public void WithUser(int userId)
        {
            if (userId.IsNotZero())
                Query = Query.Where(friendship => friendship.UserId == userId);
        }

        public void WithFriend(int friendId)
        {
            if (friendId.IsNotZero())
                Query = Query.Where(friendship => friendship.FriendId == friendId);
        }

        public void WithOnlyConfirmed(bool onlyConfirmed)
        {
            if (onlyConfirmed)
                Query = Query.Where(friendship => friendship.IsConfirmed);
        }

        public void WithOnlyUnconfirmed(bool onlyUnconfirmed)
        {
            if (onlyUnconfirmed)
                Query = Query.Where(friendship => friendship.IsConfirmed == false);
        }

        public void IncludeUser()
        {
            Query = Query.Include(friendship => friendship.User);
        }

        public void IncludeFriend()
        {
            Query = Query.Include(friendship => friendship.Friend);
        }
    }
}