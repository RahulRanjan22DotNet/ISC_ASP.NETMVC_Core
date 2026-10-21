using ISC_WebAPIDemo_Consume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks.Dataflow;

namespace ISC_WebAPIDemo_Consume.Controllers
{
    public class StudentController : Controller
    {
        private HttpClient client;
        string BaseURL = "api/Student/";

        public StudentController(HttpClient client)
        {
            this.client = client;
        }
        public IActionResult Index()
        {
            List<Student> students = null;
            try
            {
                //var handler = new HttpClientHandler
                //{
                //    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                //};

                var result = client.GetAsync(BaseURL).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    students = JsonConvert.DeserializeObject<List<Student>>(data);
                }
                return View(students);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var result = client.GetAsync(BaseURL + id).Result;
            Student _stud = null;
            if(result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsStringAsync().Result;
                _stud = JsonConvert.DeserializeObject<Student>(data);
            }
            if(_stud == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(_stud);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student stud)
        {
            if(ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(stud, Formatting.Indented);
                StringContent strContent = new StringContent(data,Encoding.UTF8, "application/json");
                var result = client.PostAsync(BaseURL, strContent).Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var joutputMsg = result.Content.ReadAsStringAsync().Result;
                    var jobj= Newtonsoft.Json.Linq.JObject.Parse(joutputMsg);
                    TempData["message"] = jobj["message"]?.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View(stud);
        }
  
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = client.GetAsync(BaseURL + id).Result;
            Student _stud = null;
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsStringAsync().Result;
                _stud = JsonConvert.DeserializeObject<Student>(data);
            }
            if (_stud == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(_stud);
            }
        }

        [HttpPost]
        public IActionResult Edit(Student stud)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(stud, Formatting.Indented);
                StringContent strContent = new StringContent(data, Encoding.UTF8, "application/json");
                var result = client.PutAsync(BaseURL + stud.Id, strContent).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(stud);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = client.DeleteAsync(BaseURL + id).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
