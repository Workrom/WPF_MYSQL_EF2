using System;
using System.Collections.Generic;

namespace WPF_MYSQL_EF2.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string StoreAdress { get; set; } = null!;

    public string StoreRegion { get; set; } = null!;

    public string StoreCeo { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
