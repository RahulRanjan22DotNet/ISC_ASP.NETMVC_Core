using ISC_WebAPIDemo_Student.Data;
using ISC_WebAPIDemo_Student.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISC_WebAPIDemo_Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> Get()
        {
            var student = await _context.Students.ToListAsync();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> Get(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var student = await _context.Students.FirstOrDefaultAsync(x=>x.Id == id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Students? student)
        {
            if (student == null)
            {
                return NotFound();
            }
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new {success = false, message = ex.InnerException.Message.ToString() });
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Students student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int? id, string Name)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(student != null)
            {
                student.StudentName = Name;
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("ByGender")]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudentsByGender(string gender)
        {
            if(gender == null)
            {
                return BadRequest();
            }
            var students = _context.Students.Where(x => x.Gender == gender).ToList();
            if (students.Count > 0)
            {
                return Ok(students);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
