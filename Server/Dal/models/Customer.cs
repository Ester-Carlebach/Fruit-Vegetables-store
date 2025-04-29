using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Customer
{
    public string CustId { get; set; } = null!;

    public string CustName { get; set; } = null!;

    public string? CustPhone { get; set; }

    public string? CustEmail { get; set; }

    public DateOnly? CustDateOfBirth { get; set; }

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
