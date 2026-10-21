using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISC_EFCore_DBFirstDemo.Models
{
    public class Student1
    {
        [Key]
        [DisplayName("Student Id")]
        public int Id { get; set; }

        [DisplayName("Student Name")]
        public string StudName { get; set; } = null!;

        public string StudGen { get; set; } = null!;

        public DateOnly StudDOB { get; set; }

        public int CId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        
    }
}
