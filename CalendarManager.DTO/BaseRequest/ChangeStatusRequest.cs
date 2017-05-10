namespace CalendarManager.DTO.BaseRequest
{
    public class ChangeStatusRequest : IdentifierBaseRequest
    {
         public bool Status { get; set; }
    }
}