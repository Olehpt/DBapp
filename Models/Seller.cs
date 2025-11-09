using System;
using System.Collections.Generic;

namespace DBapp.Models;

public partial class Seller
{
    public int SellerId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string? Picture { get; set; }

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastEditDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SellerAccount> SellerAccounts { get; set; } = new List<SellerAccount>();
}
