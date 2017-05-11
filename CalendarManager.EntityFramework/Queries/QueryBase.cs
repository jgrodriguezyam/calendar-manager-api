using System.Collections.Generic;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Infrastructure.Queries;

namespace CalendarManager.EntityFramework.Queries
{
    public class QueryBase<T> : IQuery<T> where T : class
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;
        public IQueryable<T> Query;

        public QueryBase(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }
        public void Init()
        {
            Query = _dataBaseSqlServerEntityFramework.GetQueryable<T>();
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

        public IEnumerable<T> Execute()
        {
            return Query.ToList();
        }
    }
}