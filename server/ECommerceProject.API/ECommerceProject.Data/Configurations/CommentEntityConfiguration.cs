using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations;

public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithMany();

        builder
            .HasOne(x => x.Product)
            .WithOne();
    }
}
