using ECommerceProject.Data.Configurations;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Data.Data;

/// <summary>
/// Class representing the application database context
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    /// <summary>
    /// Constructor used for setting up DbContextOptions
    /// </summary>
    /// <param name="options">DbContextOptions</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    /// <summary>
    /// Carts DbSet
    /// </summary>
    public DbSet<Cart> Carts { get; set; } = default!;

    /// <summary>
    /// Orders DbSet
    /// </summary>
    public DbSet<Order> Orders { get; set; } = default!;

    /// <summary>
    /// Payments DbSet
    /// </summary>
    public DbSet<Payment> Payments { get; set; } = default!;

    /// <summary>
    /// Products DbSet
    /// </summary>
    public DbSet<Product> Products { get; set; } = default!;

    /// <summary>
    /// Reviews DbSet
    /// </summary>
    public DbSet<Review> Reviews { get; set; } = default!;

    /// <summary>
    /// Wishlists DbSet
    /// </summary>
    public DbSet<WishList> Wishlists { get; set; } = default!;

    /// <summary>
    /// RefreshTokens DbSet
    /// </summary>
    public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;

    /// <summary>
    /// Comments DbSet
    /// </summary>
    public DbSet<Comment> Comments { get; set; } = default!;

    /// <summary>
    /// OnModelCreating method used for configuring the database
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserEntityConfiguration());
        builder.ApplyConfiguration(new CartEntityConfiguration());
        builder.ApplyConfiguration(new CommentEntityConfiguration());
        builder.ApplyConfiguration(new OrderEntityConfiguration());
        builder.ApplyConfiguration(new PaymentEntityConfiguration());
        builder.ApplyConfiguration(new ProductEntityConfiguration());
        builder.ApplyConfiguration(new ReviewEntityConfiguration());
        builder.ApplyConfiguration(new WishlistEntityConfiguration());
        
        base.OnModelCreating(builder);
    }
}