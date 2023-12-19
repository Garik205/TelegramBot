using System.ComponentModel.DataAnnotations;

namespace TelegramDataBase.Models
{
    public class User
    {
        [Required]
        [Key]
        public string ReferalKey { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public long IdChatTel { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;


        [Required]
        public string CheckRefKey { get; set; } = null!;
        
    }
}
