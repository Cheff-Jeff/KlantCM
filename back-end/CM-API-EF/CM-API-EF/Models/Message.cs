using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM_API_EF.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey("Chat")]
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }
    }
}