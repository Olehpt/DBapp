using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class OrderState
{
    public int OrderStateId { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
