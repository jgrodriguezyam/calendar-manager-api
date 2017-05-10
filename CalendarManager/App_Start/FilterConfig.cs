using System.Web.Http;
using CalendarManager.Filters;

namespace CalendarManager
{
    public class FilterConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Filters.Add(new ExceptionFilter());
        }
    }
}
