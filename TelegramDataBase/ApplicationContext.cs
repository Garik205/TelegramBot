
using Microsoft.EntityFrameworkCore;
using TelegramDataBase.Models;

namespace TelegramDataBase
{
    public class ApplicationContext : DbContext
    {
        DbSet<User> TelegramUsers { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
