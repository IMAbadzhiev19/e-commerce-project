using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

/// <summary>
/// Product entity configuration
/// </summary>
public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// Configure Product entity
    /// </summary>
    /// <param name="builder"></param>
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
            .HasPrecision(18, 3)
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