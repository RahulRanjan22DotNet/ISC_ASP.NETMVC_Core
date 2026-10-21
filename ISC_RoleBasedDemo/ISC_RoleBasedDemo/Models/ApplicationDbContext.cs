using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISC_RoleBasedDemo.Models
{
    public class ApplicationDbContext: IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base( options ) { }
         
        public DbSet<Users> Users {  get; set; }
    }
}
