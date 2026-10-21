using System;
using System.Collections.Generic;

namespace ISC_DynamicDropdown.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;
}
