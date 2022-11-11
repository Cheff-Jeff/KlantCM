namespace SignalRHub.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string ConnectionString { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public bool IsOpen { get; set; } = false;
    }
}
