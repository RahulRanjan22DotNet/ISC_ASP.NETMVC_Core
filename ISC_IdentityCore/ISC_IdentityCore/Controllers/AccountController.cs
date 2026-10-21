using ISC_IdentityCore.Models;
using ISC_IdentityCore.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ISC_IdentityCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> _signManager;
        private readonly UserManager<Users> _userManager;

        public AccountController(SignInManager<Users> signManager, UserManager<Users> userManager)
        {
            this._signManager = signManager;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users _user = new Users();
                _user.Name = model.Name;
                _user.DOB = model.DOB;
                _user.UserName = model.EmailId;
                _user.Email = model.EmailId;
                _user.PhoneNumber = model.PhoneNo;

                var result = await _userManager.CreateAsync(_user, model.Password);
                if (result.Succeeded)
                {
                    TempData["Message"] = "User Successfully Registered!! Please proceed to Login.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "User Registration Failed!");
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.EmailId, model.Password, model.RememberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Login Failed !.. Invalid Username or credentials");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            if (_signManager.IsSignedIn(User))
            {
                await _signManager.SignOutAsync();
                TempData["Message"] = "Logged Out Successfully.";
            }
            else
            {
                TempData["Message"] = "You have not signed in.";
            }
            return RedirectToAction("Login");
        }
    }
}
