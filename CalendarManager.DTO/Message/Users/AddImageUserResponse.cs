namespace CalendarManager.DTO.Message.Users
{
    public class AddImageUserResponse
    {
        public AddImageUserResponse(string imagePath)
        {
            ImagePath = imagePath;
        }

        public string ImagePath { get; set; }
    }
}