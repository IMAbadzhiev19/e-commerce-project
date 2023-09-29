using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Data.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Cart> Carts { get; set; } = default!;

    //public DbSet<Order> Orders { get; set; } = default!;

    //public DbSet<Payment> Payments { get; set; } = default!;

    public DbSet<Product> Products { get; set; } = default!;

    //public DbSet<Review> Reviews { get; set; } = default!;

    //public DbSet<Wishlist> Wishlists { get; set; } = default!;

    public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
}