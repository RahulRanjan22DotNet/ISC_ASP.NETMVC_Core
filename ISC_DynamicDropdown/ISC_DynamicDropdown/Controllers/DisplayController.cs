using ISC_DynamicDropdown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ISC_DynamicDropdown.Controllers
{
    public class DisplayController : Controller
    {
        private readonly StudentDbContext _context;

        public DisplayController(StudentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpGet]
        public JsonResult GetSubCategories(int categoryId)
        {
            var subCategories = _context.SubCategories.Where(s => s.CategoryId == categoryId)
                .Select(s => new
                {
                    s.SubCategoryId,
                    s.SubCategoryName
                }).ToList();

            return Json(subCategories);
        }
    }
}
