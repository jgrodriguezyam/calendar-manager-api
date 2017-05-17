using CalendarManager.Model;

namespace CalendarManager.DataAccess.Queries
{
    public interface ISharedLocationQuery : IQuery<SharedLocation>
    {
        void WithId(int id);
        void WithOnlyActivated(bool onlyActivated);
        void WithUser(int userId);
        void WithLocation(int locationId);
        void WithLocationOnlyToday(bool onlyToday);
        void WithLocationDate(string date);
        void IncludeUser();
        void IncludeLocation();
    }
}