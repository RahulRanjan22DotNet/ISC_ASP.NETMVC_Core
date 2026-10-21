using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISC_JWTToken_Client.Models
{
    public class LoginViewModel
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is required!")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is mandatory.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
