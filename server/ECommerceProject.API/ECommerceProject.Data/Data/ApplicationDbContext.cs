﻿using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Data.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<Cart> Carts { get; set; } = default!;

    public DbSet<Order> Orders { get; set; } = default!;

    public DbSet<Payment> Payments { get; set; } = default!;

    public DbSet<Product> Products { get; set; } = default!;

    public DbSet<Review> Reviews { get; set; } = default!;

    public DbSet<Wishlist> Wishlists { get; set; } = default!;
}