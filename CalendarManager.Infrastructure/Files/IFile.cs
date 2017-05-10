using System.IO;

namespace CalendarManager.Infrastructure.Files
{
    public interface IFile
    {
        Stream Stream { get; set; }
        string ContentType { get; set; }
        string Name { get; set; }
        string Extension { get; }
    }
}