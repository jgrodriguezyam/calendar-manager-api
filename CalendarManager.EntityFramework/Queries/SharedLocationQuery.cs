using System;
using System.Data.Entity;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Infrastructure.Dates;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Infrastructure.Strings;
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

        public void WithLocationOnlyToday(bool onlyToday)
        {
            if (onlyToday)
            {
                var today = DateTime.Now.Date;
                Query = Query.Where(sharedLocation => sharedLocation.Location.StartDate <= today && sharedLocation.Location.EndDate >= today);
            }
        }

        public void WithLocationDate(string date)
        {
            if (date.IsNotNullOrEmpty())
            {
                var dateFilter = date.DateStringToDateTime().Date;
                Query = Query.Where(sharedLocation => sharedLocation.Location.StartDate <= dateFilter && sharedLocation.Location.EndDate >= dateFilter);
            }
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