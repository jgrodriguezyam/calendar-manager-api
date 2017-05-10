namespace CalendarManager.DTO.Message.Users
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderType { get; set; }
        public string Email { get; set; }
        public long CellNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PublicKey { get; set; }
        public string Badge { get; set; }
        public string DeviceId { get; set; }
    }
}