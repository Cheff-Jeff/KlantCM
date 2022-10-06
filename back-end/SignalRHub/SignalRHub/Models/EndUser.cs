namespace SignalRHub.Models
{
    public class EndUser
    {
        public string ConnectionString { get; set; }

        public bool inRoom { get; set; }

        public EndUser(string connectionString, bool inRoom = false)
        {
            ConnectionString = connectionString;
            this.inRoom = inRoom;
        }
    }
}
