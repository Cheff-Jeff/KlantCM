namespace CM_API_EF
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string userName { get; set; } = String.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool isAdmin { get; set; }
    }
}
