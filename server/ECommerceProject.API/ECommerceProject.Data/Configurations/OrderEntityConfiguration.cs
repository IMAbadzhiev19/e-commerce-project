using Microsoft.EntityFrameworkCore;
using ECommerceProject.Data.Models.ECommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
