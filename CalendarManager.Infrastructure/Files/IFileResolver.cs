namespace CalendarManager.Infrastructure.Files
{
    public interface IFileResolver
    {
        string Resolve(string filePath);
    }
}