using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

/// <summary>
/// Comment entity configuration
/// </summary>
public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    /// <summary>
    /// Configure Comment entity
    /// </summary>
    /// <param name="builder">EntityTypeBuilder</param>
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithMany();

        builder
           .HasOne(c => c.Product)
           .WithMany(p => p.Comments)
           .HasForeignKey(c => c.ProductId);
    }
}
