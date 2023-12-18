using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace TelegramDataBase.Models
{
    public class ModelUser
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Password { get; set; } = null!;
    }
}
