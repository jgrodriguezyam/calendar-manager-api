using System.Configuration;

namespace CalendarManager.Infrastructure.Validators.Serials
{
    public static class SerialSettings
    {
        public readonly static string Serial = ConfigurationManager.AppSettings["Serial"];
    }
}