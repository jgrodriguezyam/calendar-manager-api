using System.Collections.Generic;

namespace CalendarManager.Infrastructure.Bulks
{
    public interface IBulkQuery
    {
        bool Insert(IEnumerable<object> items);
    }
}