using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithMany();

        builder
            .HasOne(x => x.Order)
            .WithOne();

        builder
            .Property(x => x.Price)
            .HasPrecision(18, 3)
            .IsRequired();
    }
}
