using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramDataBase.Models
{
    public class ModelGetRefKey
    {
        [ForeignKey("User")]
        public long chatIdTel {  get; set; }
        public string? keyRef { get; set; }
    }
}
