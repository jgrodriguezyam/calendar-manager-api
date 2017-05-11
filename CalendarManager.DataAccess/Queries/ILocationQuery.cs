using CalendarManager.Model;
using CalendarManager.Model.Enums;

namespace CalendarManager.DataAccess.Queries
{
    public interface ILocationQuery : IQuery<Location>
    {
        void WithOnlyActivated(bool onlyActivated);
        void WithName(string name);
        void WithType(ELocationType type);
        void WithUser(int userId);
        void IncludeUser();
        void IncludeSharedLocations();
    }
}