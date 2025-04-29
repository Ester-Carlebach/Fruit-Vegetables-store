using System;
using System.Collections.Generic;


namespace Dto;
public partial class Shop
{
    public int ShopId { get; set; }

    public string? CustomerCode { get; set; }

    public DateOnly? ShopDate { get; set; } 

    public decimal? TotalAmount { get; set; }

    public string? ShopNote { get; set; }
    
    public Customer Customer { get; set; }
    public List<ShopDetail> AllProducts { get; set; }
    public short? IsPay { get; set; }

}
