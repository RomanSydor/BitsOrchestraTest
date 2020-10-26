using Microsoft.EntityFrameworkCore;

namespace BitsOrchestraTest.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; } 
    }
}
