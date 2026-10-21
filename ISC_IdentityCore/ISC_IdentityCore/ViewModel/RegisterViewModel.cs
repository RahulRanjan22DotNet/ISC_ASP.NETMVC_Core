using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISC_IdentityCore.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="UserName Cannot be blank!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide a valid emailId!")]
        public string EmailId { get; set; }

        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "Please Select DOB!")]
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Please enter a valid Phone No!")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter Password!")]
        [Compare("ConfirmPassword", ErrorMessage = "Password not matched!")]
        public string Password { get; set; }

        
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
