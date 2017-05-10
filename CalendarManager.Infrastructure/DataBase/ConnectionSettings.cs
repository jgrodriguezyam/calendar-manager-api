using System.Configuration;

namespace CalendarManager.Infrastructure.DataBase
{
    public class ConnectionSettings
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionStringCalendarManager"].ConnectionString;
        } 
    }
}