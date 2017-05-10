namespace CalendarManager.DTO.BaseRequest
{
    public class FindBaseRequest
    {
        public string Sort { get; set; }
        public string SortBy { get; set; }
        public int ItemsToShow { get; set; }
        public int Page { get; set; }
    }
}