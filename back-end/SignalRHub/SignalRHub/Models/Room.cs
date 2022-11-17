namespace SignalRHub.Models
{
    public class Room : IComparable<Room>
    {
        public int Id { get; set; }
        public Employee employee { get; set; }
        public List<string> EndUserIds { get; set; } = new();

        public int CompareTo(Room? other)
        {
            if (employee.IsOpen == false) return 1;
            else if (EndUserIds.Count > other.EndUserIds.Count) return 1;
            else if (EndUserIds.Count < other.EndUserIds.Count) return -1;
            else return 0;
        }
    }
}
