using ISC_FormDataAnnotation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISC_FormDataAnnotation.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Product prod)
        {
            if(ModelState.IsValid)
            {

            }
            ModelState.AddModelError("", "Something Went Wrong !");
            return View(prod);
        }
    }
}
