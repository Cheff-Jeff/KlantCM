using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM_API_EF.Models
{
    public class User
    {
        public int userId { get; set; }
        [Required]
        public string userName { get; set; } = string.Empty;
        [ForeignKey("roleID")]
        public int RoleID { get; set; }
        public Role role { get; set; }
        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt { get; set; }
    }
}
