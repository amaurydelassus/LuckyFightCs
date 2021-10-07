using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Hero> Heroes { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            //optionsBuilder.UseSqlite($"Data Source=Database/database.db");
            optionsBuilder
                .UseMySql("server=localhost;database=luckyfightcs_database;user=admin;password=admin",
                new MySqlServerVersion("5.7.31"));
        }
    }
}
