using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM_API_EF.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}