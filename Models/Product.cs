using System;
using System.Collections.Generic;

namespace WPF_MYSQL_EF2.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal ProductFat { get; set; }

    public int PriceOne { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
