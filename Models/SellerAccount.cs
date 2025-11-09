using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class SellerAccount
{
    public int SellerAccountId { get; set; }

    public int UserId { get; set; }

    public int SellerId { get; set; }

    public virtual Seller Seller { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
