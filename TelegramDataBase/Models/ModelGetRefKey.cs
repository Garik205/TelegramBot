using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramDataBase.Models
{
    public class ModelGetRefKey
    {
        public string? keyRef { get; set; }

        [ForeignKey("User")]
        public long UserIdChatTel { get; set; }
        public User? User { get; set; }
    }
}
