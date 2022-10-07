namespace SignalRHub.Models
{
    public class Room
    {
        public int Id { get; set; }
        public Employee employee { get; set; }
        public List<string> EndUserIds { get; set; } = new();
    }
}
