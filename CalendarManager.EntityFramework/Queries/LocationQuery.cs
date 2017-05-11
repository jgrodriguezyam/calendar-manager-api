using System.Data.Entity;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Infrastructure.Strings;
using CalendarManager.Model;
using CalendarManager.Model.Enums;
using CalendarManager.Infrastructure.Enums;
using CalendarManager.Infrastructure.Integers;

namespace CalendarManager.EntityFramework.Queries
{
    public class LocationQuery : QueryBase<Location>, ILocationQuery
    {
        public LocationQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework) : base(dataBaseSqlServerEntityFramework)
        {

        }

        public void WithOnlyActivated(bool onlyActivated)
        {
            if (onlyActivated)
                Query = Query.Where(location => location.IsActive);
        }

        public void WithName(string name)
        {
            if (name.IsNotNullOrEmpty())
                Query = Query.Where(location => location.Name.Contains(name));
        }

        public void WithType(ELocationType type)
        {
            if (type.GetValue().IsNotZero())
                Query = Query.Where(location => location.Type == type);
        }

        public void WithUser(int userId)
        {
            if (userId.IsNotZero())
                Query = Query.Where(location => location.UserId == userId);
        }

        public void IncludeUser()
        {
            Query = Query.Include(location => location.User);
        }

        public void IncludeSharedLocations()
        {
            Query = Query.Include(location => location.SharedLocations);
        }
    }
}