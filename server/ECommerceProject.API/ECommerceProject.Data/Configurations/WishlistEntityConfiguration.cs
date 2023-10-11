using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

/// <summary>
/// Wishlist entity configuration
/// </summary>
public class WishlistEntityConfiguration : IEntityTypeConfiguration<Wishlist>
{
    /// <summary>
    /// Configure Wishlist entity
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithOne();

        builder
            .HasMany(x => x.Products)
            .WithMany();

    }
}
