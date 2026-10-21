using ISC_EFCore_DBFirstDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISC_EFCore_DBFirstDemo.Controllers
{
    public class CourseController : Controller
    {
        private readonly DbfirstDemoContext context;

        public CourseController(DbfirstDemoContext dbfirstDemoContext)
        {
            this.context = dbfirstDemoContext;
        }


        // GET: CourseController
        public ActionResult Index()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var courses = context.Courses.FirstOrDefault(item => item.CourseId == id);
            return View(courses);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Course _course = new Course
                {
                    CourseName = Convert.ToString(collection["CourseName"]),
                    CourseFee = Convert.ToInt32(collection["CourseFee"]),
                    CourseDuration = Convert.ToString(collection["CourseDuration"])
                };

                context.Courses.Add(_course);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var courses = context.Courses.FirstOrDefault(item => item.CourseId == id);
            return View(courses);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Course _course = new Course
                {
                    CourseId = id,
                    CourseName = Convert.ToString(collection["CourseName"]),
                    CourseFee = Convert.ToInt32(collection["CourseFee"]),
                    CourseDuration = Convert.ToString(collection["CourseDuration"])
                };
                context.Courses.Update(_course);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            var course = context.Courses.FirstOrDefault(x => x.CourseId == id);
            if (course != null)
            {
                return View(course);
            }

            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                Course _course = new Course
                {
                    CourseId = id,
                    CourseName = Convert.ToString(collection["CourseName"]),
                    CourseFee = Convert.ToInt32(collection["CourseFee"]),
                    CourseDuration = Convert.ToString(collection["CourseDuration"])
                };
                context.Courses.Remove(_course);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
