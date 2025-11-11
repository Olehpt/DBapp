using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public double Total { get; set; }

    public DateTime CreationDate { get; set; }

    public int OrderStateId { get; set; }

    public DateTime LastEditDate { get; set; }

    public int DelieveryMethodId { get; set; }

    public int PaymentMethodId { get; set; }

    public virtual DelieveryMethod DelieveryMethod { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderState OrderState { get; set; } = null!;

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    public bool IsDeleted { get; set; }
}
