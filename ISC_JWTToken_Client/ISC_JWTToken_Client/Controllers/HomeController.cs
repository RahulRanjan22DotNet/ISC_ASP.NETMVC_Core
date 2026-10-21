using ISC_JWTToken_Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISC_JWTToken_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetUserData()
        {
            var token = HttpContext.Session.GetString("JWToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("https://localhost:7263/api/Student/GetUserInfo");
            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                ViewBag.UserData = data;
            }
            else
            {
                ViewBag.UserData = "Unauthorized Access";
            }
            return View();
        }

        public async Task<IActionResult> GetAdminData()
        {
            var token = HttpContext.Session.GetString("JWToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("https://localhost:7263/api/Student/GetAdminInfo");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                ViewBag.AdminData = data;
            }
            else
            {
                ViewBag.AdminData = "Unauthorized Access Only Access by Admin User!";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
