using Microsoft.AspNetCore.Mvc;
using ISC_JWTToken_Client.Models;
using Newtonsoft.Json;


namespace ISC_JWTToken_Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();


        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");
                var result = _httpClient.PostAsync("https://localhost:7263/api/Account/Register", jsonContent).Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json");
                var result = _httpClient.PostAsync("https://localhost:7263/api/Account/login", jsonContent).Result;
                if(result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    var token = JsonConvert.DeserializeObject(data);
                    HttpContext.Session.SetString("JWToken", token.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login failed. Please check your credentials.");
                }
                
            }
            return View(model);
        }
    }
}
