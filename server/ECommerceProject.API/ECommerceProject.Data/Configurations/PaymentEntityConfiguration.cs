using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

/// <summary>
/// Payment entity configuration
/// </summary>
public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    /// <summary>
    /// Configure Payment entity
    /// </summary>
    /// <param name="builder">EntityTypeBuilder</param>
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
