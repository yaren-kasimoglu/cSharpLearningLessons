using System;
using System.Collections.Generic;

namespace AspNet_NorthwindAPI.Models.Entities;

public partial class Shipper:IEntity
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
