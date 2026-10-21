using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISC_ScaffoldingDemo.Models
{
    public class Employee
    {
        [DisplayName("Employee ID")]
        public int Id { get; set; }

        [DisplayName("Employee Name")]
        public string Name { get; set; }

        [DisplayName("Employee Designation")]
        public string Designation { get; set; }

        [DisplayName("Employee DOB")]
        public DateTime DOB { get; set; }

        [DisplayName("Employee Salary")]
        public int Salary { get; set; }
    }
}
