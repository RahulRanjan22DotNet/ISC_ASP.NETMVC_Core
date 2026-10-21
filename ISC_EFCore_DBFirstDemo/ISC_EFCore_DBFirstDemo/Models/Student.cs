using System;
using System.Collections.Generic;

namespace ISC_EFCore_DBFirstDemo.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Sname { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
