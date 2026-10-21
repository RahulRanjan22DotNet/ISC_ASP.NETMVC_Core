using Microsoft.AspNetCore.Identity;

namespace ISC_IdentityCore.Models
{
    public class Users: IdentityUser
    {
        public string Name { get; set; }
        public DateOnly DOB {  get; set; }
    }
}
