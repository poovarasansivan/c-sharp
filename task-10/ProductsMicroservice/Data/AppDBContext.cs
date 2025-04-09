using Microsoft.EntityFrameworkCore;
using ProductsMicroservice.Models;

namespace ProductsMicroservice.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}