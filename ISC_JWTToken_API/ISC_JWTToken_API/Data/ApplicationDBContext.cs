using ISC_JWTToken_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISC_JWTToken_API.Data
{
    public class ApplicationDBContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions) { }
        
    }
}
