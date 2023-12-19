using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramDataBase.Models
{
    public class ListRefKeyUser
    {
        [Required]
        public string UserName { get; set; } = null!;

        [ForeignKey("ModelGetRefKey")]
        public string RefKey { get; set; } = null!; // Внешний ключ
        public ModelGetRefKey? User { get; set; } // Навигационное свойство
    }
}
