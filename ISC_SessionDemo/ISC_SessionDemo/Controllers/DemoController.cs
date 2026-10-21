using Microsoft.AspNetCore.Mvc;

namespace ISC_SessionDemo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Name"] = HttpContext.Session.GetString("Name");
            return View();
        }

        public IActionResult AboutUs()
        {
            HttpContext.Session.GetString("Name");
            return View();
        }
    }
}
