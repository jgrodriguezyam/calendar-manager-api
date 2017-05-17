using CalendarManager.Model;
using CalendarManager.Model.Enums;

namespace CalendarManager.DataAccess.Queries
{
    public interface ICheckInQuery : IQuery<CheckIn>
    {
        void WithId(int id);
        void WithOnlyActivated(bool onlyActivated);
        void WithType(ECheckInType type);
        void WithUser(int userId);
        void WithLocation(int locationId);
        void WithCreatedOnlyToday(bool onlyToday);
        void WithCreatedDate(string date);
        void IncludeUser();
        void IncludeLocation();
    }
}