using System.Collections.Generic;
using System.Linq;
using CalendarManager.DataAccess.Queries;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Infrastructure.Queries;
using CalendarManager.Infrastructure.Strings;
using CalendarManager.Model;
using CalendarManager.Model.Enums;
using CalendarManager.Infrastructure.Enums;

namespace CalendarManager.EntityFramework.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;
        public IQueryable<User> Query;

        public UserQuery(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public void Init()
        {
            Query = _dataBaseSqlServerEntityFramework.GetDbContext().Set<User>();
        }

        public void WithOnlyActivated(bool onlyActivated)
        {
            if (onlyActivated)
                Query = Query.Where(user => user.IsActive);
        }

        public void WithFirstName(string firstName)
        {
            if (firstName.IsNotNullOrEmpty())
                Query = Query.Where(user => user.FirstName.Contains(firstName));
        }

        public void WithLastName(string lastName)
        {
            if (lastName.IsNotNullOrEmpty())
                Query = Query.Where(user => user.LastName.Contains(lastName));
        }

        public void WithGender(EGenderType genderType)
        {
            if (genderType.GetValue().IsNotZero())
                Query = Query.Where(user => user.GenderType == genderType);
        }

        public void WithEmail(string email)
        {
            if (email.IsNotNullOrEmpty())
                Query = Query.Where(user => user.Email.Contains(email));
        }

        public void WithCellNumber(long cellNumber)
        {
            if (cellNumber.IsNotZero())
                Query = Query.Where(user => user.CellNumber == cellNumber);
        }

        public void WithUserName(string userName)
        {
            if (userName.IsNotNullOrEmpty())
                Query = Query.Where(user => user.UserName.Contains(userName));
        }

        public void WithDevice(string deviceId)
        {
            if (deviceId.IsNotNullOrEmpty())
                Query = Query.Where(user => user.DeviceId == deviceId);
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

        public IEnumerable<User> Execute()
        {
            return Query.ToList();
        }
    }
}