using System.Collections.Generic;
using CalendarManager.Infrastructure.IGenericQuery;
using CalendarManager.Model;
using CalendarManager.Model.Enums;

namespace CalendarManager.DataAccess.Queries
{
    public interface ILocationQuery : IQuery
    {
        void Init();
        void WithOnlyActivated(bool onlyActivated);
        void WithName(string name);
        void WithType(ELocationType type);
        void WithUser(int userId);
        IEnumerable<Location> Execute();
    }
}