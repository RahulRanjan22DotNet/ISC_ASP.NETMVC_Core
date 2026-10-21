using System.ComponentModel.DataAnnotations;

namespace ISC_WebAPIDemo_Consume.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string Gender { get; set; }
        public string DOB { get; set; }
    }
}
