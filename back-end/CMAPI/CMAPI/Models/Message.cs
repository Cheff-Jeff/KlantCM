namespace CMAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; } = string.Empty;
        public int RoomId { get; set; }
    }
}
