using ShopAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//product ORM to adjust database performance

namespace ShopAPI.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Title).HasColumnType("varchar(100)");
            builder.Property(x => x.Description).HasColumnType("varchar(200)");
            builder.HasOne(x => x.Category).WithMany(x => x.Products).IsRequired();

        }
    }
}
