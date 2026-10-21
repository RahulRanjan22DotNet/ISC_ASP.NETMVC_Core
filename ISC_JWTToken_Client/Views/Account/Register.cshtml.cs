using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISC_JWTToken_Client.Views.Account
{
    public class RegisterModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}