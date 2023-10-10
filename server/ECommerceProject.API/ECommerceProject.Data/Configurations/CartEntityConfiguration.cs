using ECommerceProject.Data.Models;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

public class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
{
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