using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;
using ShopAPI.Data.Maps;


namespace ShopAPI.Data
{
    public class DataContextShopDTO : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optsBuilder)
        {
            optsBuilder.UseSqlServer(@"Server=localhost,1433;Database=shopDB;User ID=sa;Password=root");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());

        }

        //constructor of dataContext used by the addDataContex to load a DTO in memory
        public DataContextShopDTO(DbContextOptions<DataContextShopDTO> opts) : base(opts)
        { }

    }
}
