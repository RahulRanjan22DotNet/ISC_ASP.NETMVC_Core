using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISC_IdentityCore.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Provide a valid emailId!")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please enter Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
