using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TelegramDataBase.Models;

namespace TelegramDataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> RegistrationUsers { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public ApplicationContext() 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            Database.EnsureCreated();
            optionsBuilder.UseSqlite("Data Source=DBtelegram.db");
        }
    }
}
