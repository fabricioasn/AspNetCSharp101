using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;
namespace ShopAPI.Data
{
    public class DataContextShopDTO:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optsBuilder)
        {
            optsBuilder.UseSqlServer(@"Server=localhost, 1433;Database=shopDB;User ID=sa;Password=root");
        }

    }
}
