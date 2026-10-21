using ISC_DependencyInjectionDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISC_DependencyInjectionDemo.Controllers
{
    public class CalculationController : Controller
    {
        /*
         //Constructor Dependency Injection
        private ICalculationService _calculatorService;
        public CalculationController(ICalculationService calculatorService)
        {
            this._calculatorService = calculatorService;
        }
        */

        [FromServices]
        //Property Dependency Injection
        public ICalculationService _calculatorService { get; set; }

        //Method Dependency Injection
        public IActionResult Index([FromServices] ICalculationService service)
        {
            ViewBag.Result = service.Add(10, 20);
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firstNumber, string secondNumber, string operation)
        {
            int x = Convert.ToInt32(firstNumber);
            int y = Convert.ToInt32(secondNumber);
            int result = 0;
            if (operation.Equals("add"))
            {
                result = _calculatorService.Add(x, y);
            }
            else if (operation.Equals("sub"))
            {
                result = _calculatorService.Sub(x, y);
            }
            else if (operation.Equals("mul"))
            {
                result = _calculatorService.Multiply(x, y);
            }
            else
            {
                result = _calculatorService.Divide(x, y);
            }
            TempData["Result"] = result;
            return RedirectToAction("ShowResult");
        }

        public IActionResult ShowResult()
        {
            return View();
        }
    }
}
