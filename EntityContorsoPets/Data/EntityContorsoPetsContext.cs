using EntityContorsoPets.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityContorsoPets.Data
{
    public class EntityContorsoPetsContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EntityContorsoPets;Integrated Security=True; ConnectRetryCount=0");
        }
    }
}
