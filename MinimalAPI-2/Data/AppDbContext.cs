using Microsoft.EntityFrameworkCore;
using MinimalAPI_2.Models;

namespace MinimalAPI_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies=> Set<Movie>();
    }
}