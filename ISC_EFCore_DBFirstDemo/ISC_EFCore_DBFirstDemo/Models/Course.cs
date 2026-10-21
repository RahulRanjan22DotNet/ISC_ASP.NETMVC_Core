using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISC_EFCore_DBFirstDemo.Models;

public partial class Course
{
    [Key]
    [DisplayName("Course Id")]
    public int CourseId { get; set; }

    [DisplayName("Course Name")]
    [Required(ErrorMessage ="Please enter Course Name")]
    public string CourseName { get; set; } = null!;

    [DisplayName("Course Name")]
    [Required(ErrorMessage = "Please enter Course Duration")]
    public string CourseDuration { get; set; } = null!;

    [DisplayName("Course Fees")]
    [Required(ErrorMessage = "Please enter Course Fees")]
    public int? CourseFee { get; set; }
}
