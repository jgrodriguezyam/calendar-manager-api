using System.Collections.Generic;
using CalendarManager.Infrastructure.IGenericQuery;
using CalendarManager.Model;
using CalendarManager.Model.Enums;

namespace CalendarManager.DataAccess.Queries
{
    public interface IUserQuery : IQuery
    {
        void Init();
        void WithOnlyActivated(bool onlyActivated);
        void WithFirstName(string firstName);
        void WithLastName(string lastName);
        void WithGender(EGenderType genderType);
        void WithEmail(string email);
        void WithCellNumber(long cellNumber);
        void WithUserName(string userName);
        void WithDevice(string deviceId);
        IEnumerable<User> Execute();
    }
}