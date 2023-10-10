using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
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
