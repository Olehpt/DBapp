using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBapp.Models;
[Index(nameof(UnitPrice), IsUnique = false)]
public partial class Product
{
    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public int SellerId { get; set; }

    public double UnitPrice { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastEditDate { get; set; }

    public int? CategoryId { get; set; }

    public int Quantity { get; set; }

    public int ProductStatusId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductStatus ProductStatus { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Seller Seller { get; set; } = null!;

    public virtual ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
}
