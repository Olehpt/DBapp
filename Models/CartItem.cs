using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
