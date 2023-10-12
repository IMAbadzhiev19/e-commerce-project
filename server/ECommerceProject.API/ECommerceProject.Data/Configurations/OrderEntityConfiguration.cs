using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

/// <summary>
/// Order entity configuration
/// </summary>
public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    /// <summary>
    /// Configure Order entity
    /// </summary>
    /// <param name="builder">EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
             .HasOne(x=>x.Cart)
             .WithOne();

        builder
            .HasOne(x => x.User)
            .WithMany();
    }
}
