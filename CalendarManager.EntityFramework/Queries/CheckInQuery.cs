using System.Data.Entity;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Infrastructure.Enums;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Model;
using CalendarManager.Model.Enums;

namespace CalendarManager.EntityFramework.Queries
{
    public class CheckInQuery : QueryBase<CheckIn>, ICheckInQuery
    {
        public CheckInQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework) 
            : base(dataBaseSqlServerEntityFramework)
        {
        }

        public void WithId(int id)
        {
            if (id.IsNotZero())
                Query = Query.Where(checkIn => checkIn.Id == id);
        }

        public void WithOnlyActivated(bool onlyActivated)
        {
            if (onlyActivated)
                Query = Query.Where(checkIn => checkIn.IsActive);
        }

        public void WithType(ECheckInType type)
        {
            if (type.GetValue().IsNotZero())
                Query = Query.Where(checkIn => checkIn.Type == type);
        }

        public void WithUser(int userId)
        {
            if (userId.IsNotZero())
                Query = Query.Where(checkIn => checkIn.UserId == userId);
        }

        public void WithLocation(int locationId)
        {
            if (locationId.IsNotZero())
                Query = Query.Where(checkIn => checkIn.LocationId == locationId);
        }

        public void IncludeUser()
        {
            Query = Query.Include(checkIn => checkIn.User);
        }

        public void IncludeLocation()
        {
            Query = Query.Include(checkIn => checkIn.Location);
        }
    }
}