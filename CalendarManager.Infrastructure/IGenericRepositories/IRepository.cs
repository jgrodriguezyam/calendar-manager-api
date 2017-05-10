namespace CalendarManager.Infrastructure.IGenericRepositories
{
    public interface IRepository<T> : IReadableRepository<T>, IWritableRepository<T>
    {
         
    }
}