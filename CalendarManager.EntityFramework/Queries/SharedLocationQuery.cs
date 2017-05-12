using System.Data.Entity;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.Queries
{
    public class SharedLocationQuery : QueryBase<SharedLocation>, ISharedLocationQuery
    {
        public SharedLocationQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework) 
            : base(dataBaseSqlServerEntityFramework)
        {
        }

        public void WithId(int id)
        {
            if (id.IsNotZero())
                Query = Query.Where(sharedLocation => sharedLocation.Id == id);
        }

        public void WithOnlyActivated(bool onlyActivated)
        {
            if (onlyActivated)
                Query = Query.Where(sharedLocation => sharedLocation.IsActive);
        }

        public void WithUser(int userId)
        {
            if (userId.IsNotZero())
                Query = Query.Where(sharedLocation => sharedLocation.UserId == userId);
        }

        public void WithLocation(int locationId)
        {
            if (locationId.IsNotZero())
                Query = Query.Where(sharedLocation => sharedLocation.LocationId == locationId);
        }

        public void IncludeUser()
        {
            Query = Query.Include(sharedLocation => sharedLocation.User);
        }

        public void IncludeLocation()
        {
            Query = Query.Include(sharedLocation => sharedLocation.Location);
        }
    }
}