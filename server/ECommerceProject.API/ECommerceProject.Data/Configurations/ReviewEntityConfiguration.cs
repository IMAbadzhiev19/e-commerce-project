using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

/// <summary>
/// Review entity configuration
/// </summary>
public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
{
    /// <summary>
    /// Configure Review entity
    /// </summary>
    /// <param name="builder">EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithMany();

        builder
           .HasOne(c => c.Product)
           .WithMany(p => p.Reviews)
           .HasForeignKey(c => c.ProductId);
    }
}
