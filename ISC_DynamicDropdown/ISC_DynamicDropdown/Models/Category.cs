using System;
using System.Collections.Generic;

namespace ISC_DynamicDropdown.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
