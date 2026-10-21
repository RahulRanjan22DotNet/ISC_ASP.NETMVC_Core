using ISC_EFCore_CodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ISC_EFCore_CodeFirstDemo.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student {  get; set; }
        public DbSet<Course> Courses { get; set; }
        protected ApplicationDbContext()
        {
        }

    }
}
