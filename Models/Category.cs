using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string? Picture { get; set; }
    //soft delete
    public bool IsDeleted { get; set; } = false;
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
