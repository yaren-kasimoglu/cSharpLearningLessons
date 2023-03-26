using System;
using System.Collections.Generic;

namespace AspNet_NorthwindAPI.Models.Entities;

public partial class Category:IEntity
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
