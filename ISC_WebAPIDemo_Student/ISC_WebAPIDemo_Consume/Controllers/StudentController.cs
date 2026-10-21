using ISC_WebAPIDemo_Consume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ISC_WebAPIDemo_Consume.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
        string BaseURL = "https://localhost:7210/api/Student";
        public IActionResult Index()
        {
            List<Students> students = null;
            var result = client.GetAsync(BaseURL).Result;
            if(result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<Students>>(data);
            }
            return View(students);
        }
    }
}
