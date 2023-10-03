using ECommerceProject.Data.Models;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //Setup primary and foreign keys
        builder
            .HasKey(x => x.Id);

        builder
            .HasMany(x => x.Carts)
            .WithMany(x => x.Products);

        //Setups constraints
        builder
            .Property(x => x.Title)
            .HasMaxLength(300)
            .IsRequired();

        builder
            .Property(x => x.Price)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasMaxLength(400)
            .IsRequired(false);

        builder
            .Property(x => x.ImageUrl)
            .IsRequired(false);

        builder
            .Property(x => x.Quantity)
            .IsRequired();

        builder
            .Property(x => x.Category)
            .IsRequired();
    }
}