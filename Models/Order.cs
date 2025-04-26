using System;
using System.Collections.Generic;

namespace WPF_MYSQL_EF2.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int StoreId { get; set; }

    public int ProductId { get; set; }

    public int AmountOrdered { get; set; }

    public DateOnly OrderDate { get; set; }

    public int? AmountDelivered { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
