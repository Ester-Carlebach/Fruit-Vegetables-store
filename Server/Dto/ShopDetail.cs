using System;
using System.Collections.Generic;

namespace Dto;

public partial class ShopDetail
{
    public int ShopDetailsId { get; set; }

    public int? ShopCode { get; set; }

    public int? ProductCode { get; set; }

    public int? Quantity { get; set; }
    public Product Product { get; set; }



}
