namespace SignalRHub.Models
{
    public class EndUser
    {
        public string ConnectionString { get; set; }

        public bool inRoom { get; set; }

        public int RoomId { get; set; } = -1;

        public EndUser(string connectionString, bool inRoom = false)
        {
            ConnectionString = connectionString;
            this.inRoom = inRoom;
        }
    }
}
