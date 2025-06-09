using Microsoft.EntityFrameworkCore;
using Restaurant.DataContext.Entities;

namespace Restaurant.DataContext
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OfflineOrder> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<ReserveTable> ReserveTables { get; set; }
      
    }
}
