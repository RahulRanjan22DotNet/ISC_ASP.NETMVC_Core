using ISC_EFCore_CodeFirstDemo.Data;
using ISC_EFCore_CodeFirstDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISC_EFCore_CodeFirstDemo.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course _course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(_course);
                _context.SaveChanges();
                TempData["Message"] = "Course Successfully Added !";
                return RedirectToAction("Index");
            }
            return View(_course);
        }

        public IActionResult Details(int? Id)
        {
            if(Id == null)
            {
                TempData["Message"] = "Please provide Course Id to view details !";
                return RedirectToAction("Index");
            }
            else
            {
                var course = _context.Courses.FirstOrDefault(x=>x.CourseId == Id);
                if (course != null)
                {
                    return View(course);
                }
                else
                {
                    TempData["Message"] = "No details Found. Invalid Course Id !";
                    return RedirectToAction("Index");
                }
            }
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                TempData["Message"] = "Please provide Course Id to Edit !";
                return RedirectToAction("Index");
            }
            else
            {
                var course = _context.Courses.FirstOrDefault(x => x.CourseId == Id);
                if (course != null)
                {
                    return View(course);
                }
                else
                {
                    TempData["Message"] = "No details Found. Invalid Course Id !";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public IActionResult Edit(Course _course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(_course);
                _context.SaveChanges();
                TempData["Message"] = "Course Updated Successfully !";
                return RedirectToAction("Index");
            }
            return View(_course);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                TempData["Message"] = "Please provide Course Id to delete !";
                return RedirectToAction("Index");
            }
            else
            {
                var course = _context.Courses.FirstOrDefault(x => x.CourseId == Id);
                if (course != null)
                {
                    return View(course);
                }
                else
                {
                    TempData["Message"] = "Delete Failed. Invalid Course Id !";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public IActionResult Delete(Course _course)
        {
            if (_course != null)
            {
                _context.Courses.Remove(_course);
                _context.SaveChanges();
                TempData["Message"] = "Course Deleted Successfully !";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Delete Failed. Something went Wrong !";
            return RedirectToAction("Index");
        }

    }
}
