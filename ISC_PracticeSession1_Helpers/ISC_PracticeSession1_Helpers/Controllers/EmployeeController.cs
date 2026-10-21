using ISC_PracticeSession1_Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISC_PracticeSession1_Helpers.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowData(Employee model)
        {
            return View(model);
        }
    }
}
