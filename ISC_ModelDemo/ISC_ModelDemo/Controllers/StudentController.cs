using ISC_ModelDemo.Models;
using ISC_ModelDemo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ISC_ModelDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student stud = new Student() { Roll = 1, Name = "Rahul Ranjan", Gender = "Male", DOB = new DateTime(1998,09,22) };
            //StudentViewModel _viewModel = new StudentViewModel() { Name= stud.Name, Gender = stud.Gender };
            //return View(_viewModel);
            return View(stud);
        }

        // Using Action Method Parameters (Query String)
        public IActionResult ShowData(string name, string fname, string gender, string dob, string disability)
        {
            ViewBag.Name = name;
            ViewBag.Fname = fname;
            ViewBag.Gender = gender;
            ViewBag.Dob = dob;
            ViewBag.Disability = disability;
            return View();
        }

        //Using Request Form
        //public IActionResult RegisterData()
        //{
        //    ViewBag.Name  = Request.Form["name"];
        //    ViewBag.Fname = Request.Form["fname"];
        //    ViewBag.Gender = Request.Form["gender"];
        //    ViewBag.Dob = Request.Form["dob"];
        //    ViewBag.Disability = Request.Form["disability"];
        //    return View();
        //}

        // Using IFormCollection
        //public IActionResult RegisterData(IFormCollection form)
        //{
        //    ViewBag.Name = form["name"];
        //    ViewBag.Fname = form["fname"];
        //    ViewBag.Gender = form["gender"];
        //    ViewBag.Dob = form["dob"];
        //    ViewBag.Disability = form["disability"];
        //    return View();
        //}

        //Using Stringly Typed Binding (Model Binding)
        public IActionResult RegisterData(Student stud)
        {
            return View(stud);
        }
    }
}
