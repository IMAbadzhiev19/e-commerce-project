using ECommerceProject.Data.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
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