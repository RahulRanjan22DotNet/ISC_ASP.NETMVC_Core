using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISC_JWTToken_Client.Models
{
    public class RegisterViewModel
    {
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Email Id")]
        [EmailAddress(ErrorMessage = "Email Id is mandatory.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is mandatory.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password and Confirm Password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "Role is Required.")]
        public string Role { get; set; }
    }
}
