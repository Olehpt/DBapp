using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class ProductStatus
{
    public int ProductStatusId { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
