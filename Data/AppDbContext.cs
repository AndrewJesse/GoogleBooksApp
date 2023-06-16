using GoogleBooksApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GoogleBooksApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=app.db");
    }

}
