using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceProject.Data.Configurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithMany();

            builder
                .HasOne(x=>x.Product)
                .WithMany();
        }
    }
}
