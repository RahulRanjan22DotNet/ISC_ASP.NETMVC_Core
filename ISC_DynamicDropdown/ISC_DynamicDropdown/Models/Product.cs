using System;
using System.Collections.Generic;

namespace ISC_DynamicDropdown.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public string? ProductCategory { get; set; }

    public float PurchasePrice { get; set; }

    public float SalePrice { get; set; }

    public DateTime CreatedOn { get; set; }
}
