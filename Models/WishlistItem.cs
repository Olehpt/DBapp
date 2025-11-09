using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class WishlistItem
{
    public int WishlistItemId { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
