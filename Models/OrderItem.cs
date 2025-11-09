using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int Quantity { get; set; }

    public double Total { get; set; }

    public double UnitPrice { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
