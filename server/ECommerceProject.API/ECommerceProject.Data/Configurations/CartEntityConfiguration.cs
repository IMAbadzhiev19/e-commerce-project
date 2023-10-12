using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

/// <summary>
/// Cart entity configuration
/// </summary>
public class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
{
    /// <summary>
    /// Configure Cart entity
    /// </summary>
    /// <param name="builder">EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        //Setup primary and foreign keys
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasMany(x => x.Products)
            .WithMany(x => x.Carts);

        builder
            .HasOne(x => x.User)
            .WithMany();
    }
}