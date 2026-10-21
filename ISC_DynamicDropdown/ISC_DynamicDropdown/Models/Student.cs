using System;
using System.Collections.Generic;

namespace ISC_DynamicDropdown.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Dob { get; set; } = null!;
}
