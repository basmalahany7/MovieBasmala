using Microsoft.EntityFrameworkCore;
using MovieBasmala.Models;

namespace MovieBasmala
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director>Directors { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
    }
}
