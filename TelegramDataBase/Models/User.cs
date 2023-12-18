using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TelegramDataBase.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Password { get; set; } = null!;
        public long IdChatTel { get; set; }
    }
}
