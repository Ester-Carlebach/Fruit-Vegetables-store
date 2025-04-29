using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Category
{
    public int CatId { get; set; }

    public string CatName { get; set; } = null!;

    public int? CompId { get; set; }

    public virtual Company? Comp { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
