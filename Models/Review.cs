using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public string? Content { get; set; }

    public int Value { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
