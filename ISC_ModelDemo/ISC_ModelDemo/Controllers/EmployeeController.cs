using ISC_ModelDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISC_ModelDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()    
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { EmpId = "EMP-001", EmpName = "Rahul Ranjan", Gender = "M", Department = "IT", DOB = new DateTime(1988, 09, 22), DOJ = new DateTime(2021, 02, 01) },
                new Employee { EmpId = "EMP-002", EmpName = "Rahul Sharma", Gender = "M", Department = "Accounts", DOB = new DateTime(1933, 11, 12), DOJ = new DateTime(2021, 02, 01) },
                new Employee { EmpId = "EMP-003", EmpName = "Payal Gupta", Gender = "F", Department = "HR", DOB = new DateTime(1988, 09, 22), DOJ = new DateTime(2021, 02, 01) }
            };
            
            //Employee _emp = new Employee();
            return View(employees);
        }
    }
}
