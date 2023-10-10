using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

public class WishlistEntityConfiguration : IEntityTypeConfiguration<Wishlist>
{
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
