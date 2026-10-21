using ISC_CleanWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ISC_CleanWebApp.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
