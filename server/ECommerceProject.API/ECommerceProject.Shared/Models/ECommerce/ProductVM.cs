﻿using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Shared.Models.ECommerce;

/// <summary>
/// Product View Model
/// </summary>
public class ProductVM
{
    public Guid Id { get; set; }

    /// <summary>
    /// The Title of the product
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The price of the product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The description of the product
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The URL of the product's image
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the product
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// The category of the product
    /// </summary>
    public string Category { get; set; } = string.Empty;

    public virtual ICollection<Comment> Comments { get; set; } = default!;

    public virtual ICollection<Review> Reviews { get; set; } = default!;
}