using CalendarManager.Model;

namespace CalendarManager.DataAccess.Queries
{
    public interface ISharedLocationQuery : IQuery<SharedLocation>
    {
        void WithId(int id);
        void WithOnlyActivated(bool onlyActivated);
        void WithUser(int userId);
        void WithLocation(int locationId);
        void IncludeUser();
        void IncludeLocation();
    }
}