namespace CM_API_EF.Models
{
    public class Role
    {
        public int roleID { get; set; }
        public RoleType roleType { get; set; }
    }
    public enum RoleType
    {
        Service, Admin
    }
}
