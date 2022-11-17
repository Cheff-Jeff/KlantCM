using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CM_API_EF.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        public bool Rate { get; set; }


        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        public DateTime TimeOfRating { get; set; }
    }
}