using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ISC_RoleBasedDemo.Models
{
    public class Users :IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}
