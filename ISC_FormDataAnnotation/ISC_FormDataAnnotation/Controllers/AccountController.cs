using ISC_FormDataAnnotation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISC_FormDataAnnotation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}
