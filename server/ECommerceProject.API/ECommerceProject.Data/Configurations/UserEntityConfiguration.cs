using ECommerceProject.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

/// <summary>
/// User entity configuration
/// </summary>
public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    /// <summary>
    /// Configure User entity
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        //Setups primary and foreign keys
        builder
            .HasKey(x => x.Id);

        //Setups contstraints
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(70)
            .IsRequired();

        builder
            .Property(x => x.LastName)
            .HasMaxLength(70)
            .IsRequired();

        //Setups value objects
        builder
            .OwnsOne(x => x.Address);
    }
}