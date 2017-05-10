namespace CalendarManager.Infrastructure.IGenericQuery
{
    public interface IQuery
    {
        void Sort(string sort, string sortBy);
        void Paginate(int itemsToShow, int page);
        int TotalRecords();
    }
}