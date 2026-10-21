using ISC_SessionDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISC_SessionDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string? Name)
        {
            if(Name != null)
            {
                HttpContext.Session.SetString("Name", Name);
                return RedirectToAction("Success");
            }
            return View();
        }

        public IActionResult Success()
        {
            ViewData["Name"] = HttpContext.Session.GetString("Name");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
