using System.ComponentModel.DataAnnotations;

namespace TelegramDataBase.Models
{
    public class User
    {
        [Required]
        public long IdChatTel { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string ReferalKey { get; set; } = Guid.NewGuid().ToString();
    }
}
