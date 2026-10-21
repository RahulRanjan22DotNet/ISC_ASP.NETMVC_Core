using System.ComponentModel.DataAnnotations;

namespace ISC_PracticeSession1_Helpers.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
}
