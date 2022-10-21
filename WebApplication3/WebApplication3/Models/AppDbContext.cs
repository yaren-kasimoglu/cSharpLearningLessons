using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Order> Orders { get; set; } = default;
    }
}
