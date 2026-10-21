

using ISC_WebAPIDemo_Student.Models;
using Microsoft.EntityFrameworkCore;

namespace ISC_WebAPIDemo_Student.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Students> Students { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
