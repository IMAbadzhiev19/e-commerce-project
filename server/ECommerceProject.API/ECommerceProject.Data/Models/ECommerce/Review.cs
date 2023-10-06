﻿using ECommerceProject.Data.Models.Auth;

namespace ECommerceProject.Data.Models.ECommerce;

public class Review
{
    public Guid Id { get; set; }
    
    public string? UserId { get; set; }

    public ApplicationUser? User { get; set; }

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }

    public int? Grade { get; set; }
}
