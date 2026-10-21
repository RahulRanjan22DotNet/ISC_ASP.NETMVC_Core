using ISC_EFCore_CodeFirstDemo.Data;
using ISC_EFCore_CodeFirstDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISC_EFCore_CodeFirstDemo.Controllers
{
    public class StudentController : Controller
    {
        public readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var student = _context.Student.ToList();
            return View(student);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["Message"] = "Please provide Student Id to view details !";
                return RedirectToAction("Index");
            }
            else
            {
                var student = _context.Student.FirstOrDefault(x => x.Id == id);
                if (student != null)
                {
                    return View(student);
                }
                else
                {
                    TempData["Message"] = "No details Found. Invalid Student Id !";
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student _student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Student.Add(_student);
                    _context.SaveChanges();
                    TempData["Message"] = "Student Successfully Added !";
                    return RedirectToAction("Index");
                }
                return View(_student);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["Message"] = "Please provide Student Id to Edit !";
                return RedirectToAction("Index");
            }
            else
            {
                var student = _context.Student.FirstOrDefault(x => x.Id == id);
                if (student != null)
                {
                    return View(student);
                }
                else
                {
                    TempData["Message"] = "No details Found. Invalid Student Id !";
                    return RedirectToAction("Index");
                }
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student _student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Student.Update(_student);
                    _context.SaveChanges();
                    TempData["Message"] = "Student Updated Successfully !";
                    return RedirectToAction("Index");
                }
                return View(_student);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["Message"] = "Please provide Student Id to delete !";
                return RedirectToAction("Index");
            }
            else
            {
                var student = _context.Student.FirstOrDefault(x => x.Id == id);
                if (student != null)
                {
                    return View(student);
                }
                else
                {
                    TempData["Message"] = "Delete Failed. Invalid Student Id !";
                    return RedirectToAction("Index");
                }
            }
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student _student)
        {
            try
            {
                if (_student != null)
                {
                    _context.Student.Remove(_student);
                    _context.SaveChanges();
                    TempData["Message"] = "Student Deleted Successfully !";
                    return RedirectToAction("Index");
                }
                TempData["Message"] = "Delete Failed. Something went Wrong !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
