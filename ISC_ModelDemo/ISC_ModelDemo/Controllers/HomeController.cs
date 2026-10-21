using ISC_ModelDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISC_ModelDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowData()
        {
            ViewData["Roll"] = 101;
            ViewData["Name"] = "Rahul Ranjan";
            ViewData["Course"] = "ASP.NET MVC Core";
            ViewData["Fee"] = 6500;

            ViewBag.Roll = 102;
            ViewBag.Name = "David Samuel";
            ViewBag.Course = "ASP.NET MVC Core";
            ViewBag.Fee = 9500;
            return View();
        }

        public IActionResult Action1(string fn, string sn)
        {
            //ViewData["Message"] = "Hi, This is Message coming from Action 1";
            TempData["Message"] = "Hi, This is Message coming from Action 1";
            int n1 = Convert.ToInt32(fn);
            int n2 = Convert.ToInt32(sn);
            int res = n1 + n2;
            TempData["Result"] = res;
            return RedirectToAction("Action2");
        }

        public IActionResult Action2()
        {
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
