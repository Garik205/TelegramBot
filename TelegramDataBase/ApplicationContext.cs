using Microsoft.EntityFrameworkCore;
using TelegramDataBase.Models;

namespace TelegramDataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> RegistrationUsers { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public ApplicationContext() { }
    }
}
