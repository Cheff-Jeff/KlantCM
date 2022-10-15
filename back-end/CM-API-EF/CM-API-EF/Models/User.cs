using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CM_API_EF.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }

        [Required]
        public string userName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Required]
        public bool isAdmin { get; set; }

        //[ForeignKey("roleID")]
        //public int RoleID { get; set; }

        //[JsonIgnore]
        //public Role role { get; set; }

        [Required]
        public string passwordHash { get; set; } = string.Empty;
    }
}
