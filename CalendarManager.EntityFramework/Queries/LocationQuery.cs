using System.Collections.Generic;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Infrastructure.Queries;
using CalendarManager.Infrastructure.Strings;
using CalendarManager.Model;
using CalendarManager.Model.Enums;
using CalendarManager.Infrastructure.Enums;
using CalendarManager.Infrastructure.Integers;

namespace CalendarManager.EntityFramework.Queries
{
    public class LocationQuery : ILocationQuery
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;
        public IQueryable<Location> Query;

        public LocationQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public void Init()
        {
            Query = _dataBaseSqlServerEntityFramework.GetDbContext().Set<Location>();
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

        public void Sort(string sort, string sortBy)
        {
            Query = QueryFactory.SortByPropertyResolver(sort, sortBy, Query);
        }

        public void Paginate(int itemsToShow, int page)
        {
            Query = QueryFactory.PaginationResolver(itemsToShow, page, Query);
        }

        public int TotalRecords()
        {
            return Query.Count();
        }

        public IEnumerable<Location> Execute()
        {
            return Query.ToList();
        }
    }
}