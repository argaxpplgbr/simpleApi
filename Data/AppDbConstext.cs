using Microsoft.EntityFrameworkCore;
using SimpleApi.Models;

namespace SimpleApi.Data
{
    // DbContext = jembatan antara C# dan database
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Setiap DbSet = 1 tabel di database
        public DbSet<Product> Products => Set<Product>();
    }
}