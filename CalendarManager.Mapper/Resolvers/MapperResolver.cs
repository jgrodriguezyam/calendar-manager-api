using CalendarManager.Infrastructure.Files;
using CalendarManager.Infrastructure.Strings;

namespace CalendarManager.Mapper.Resolvers
{
    public static class MapperResolver
    {
        public static string MultimediaPath(string fileName)
        {
            if(fileName.IsNotNullOrEmpty())
                return string.Format("{0}{1}{2}", ServerDomainResolver.GetCurrentDomain(), FileSettings.ContentFolder, fileName);
            return string.Empty;
        }
    }
}