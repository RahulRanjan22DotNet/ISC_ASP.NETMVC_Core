using ISC_WebAPIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISC_WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private List<Student> students = new List<Student>
        {
            new Student {StudentId = 1,StudentName = "Rahul", Gender ="Male", DOB = "22 Sep 1987" },
            new Student {StudentId = 2,StudentName = "Jitesh", Gender ="Male", DOB = "29 Jan 1981" },
            new Student {StudentId = 3,StudentName = "Gauri", Gender ="Female", DOB = "04 Dec 2001" },
        };

        [HttpGet("GetStudents")]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            var st = students.FirstOrDefault(x => x.StudentId == id);
            return st;
        }
    }
}
