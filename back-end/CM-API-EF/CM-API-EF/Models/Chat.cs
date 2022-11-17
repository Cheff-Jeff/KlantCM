using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM_API_EF.Models
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        //MAYBE TO DO: statistics(timer, messages sent etc)
    }
}