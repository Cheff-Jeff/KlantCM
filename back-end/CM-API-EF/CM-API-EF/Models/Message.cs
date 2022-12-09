using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CM_API_EF.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string Text { get; set; }
        public bool Worker { get; set; }
        [ForeignKey("Chat")]
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }

        public byte []? MessageData { get; set; }

    }
}