using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISC_FormDataAnnotation.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        [DisplayName("Enter User Name")]
        
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password cannot be empty.")]
        [StringLength(50, MinimumLength =8, ErrorMessage = "Password length must be atleast 8 characters and less than 50 characters.")]
        [DisplayName("Enter Password")]
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,50}$",
        ErrorMessage = "Password must be 8-50 characters long and contain uppercase, lowercase, number and special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password cannot be empty")]
        [DisplayName("Enter Confirm Password")]
        [Compare("Password", ErrorMessage ="Confirm Password not matched with Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Name cannot be empty.")]
        [DisplayName("Enter Full Name")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email Id")]
        [DisplayName("Enter Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number cannot be empty.")]
        [DisplayName("Enter Contact Phone Number")]
        [Phone(ErrorMessage ="Invalid Phone Number")]
        public string Phone { get; set; }
    }
}
