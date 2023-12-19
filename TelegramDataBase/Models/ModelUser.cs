using System.ComponentModel.DataAnnotations;

namespace TelegramDataBase.Models
{
    public class ModelUser
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public long IdChatTel { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [MinLength(5)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполения")]
        public string CheckRefKey { get; set; } = null!;
    }
}
