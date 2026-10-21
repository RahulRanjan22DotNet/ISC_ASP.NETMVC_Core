using ISC_ScaffoldingDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISC_ScaffoldingDemo.Controllers
{
    [Route("emp")]
    public class EmployeeController : Controller
    {
        List<Employee> employees = new List<Employee> {
                                                        new Employee{Id=1001, Name = "Rahul Ranjan", Designation = "Head", DOB = new DateTime(1988,09,22), Salary = 45000},
                                                        new Employee{Id=1002, Name = "Payal Gupta", Designation = "Clerk", DOB = new DateTime(1918,09,08), Salary = 45000},
                                                        new Employee{Id=1003, Name = "Suresh Yadav", Designation = "Manager", DOB = new DateTime(1918,09,12), Salary = 45000},
                                                        new Employee{Id=1004, Name = "Nancy Sharma", Designation = "Peon", DOB = new DateTime(1989,09,29), Salary = 45000},
                                                        new Employee{Id=1005, Name = "Geeta Sabanti", Designation = "Receptionist", DOB = new DateTime(1988,01,12), Salary = 45000}
                                                       };
        [Route("list_of_employees")]
        public IActionResult Index()
        {
            return View(employees);
        }

        [Route("add_employees")]
        public IActionResult Create()
        {
            return View();
        }

        //[Route("employee_details/{id}")]
        [Route("employee_details/{id:int}")]
        public IActionResult Edit(int? id)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);
            return View(emp);
        }

        public IActionResult Details(int id)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);
            return View(emp);
        }
    }
}
