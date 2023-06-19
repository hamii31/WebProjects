using Microsoft.AspNetCore.Mvc;
using PowerliftingCalculator.Models;
using PowerliftingCalculator.Models.CalculatorViewModel;
using PowerliftingCalculator.Service.Interfaces;
using System.Diagnostics;

namespace PowerliftingCalculator.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICalculatorService calculatorService;
		public HomeController(ICalculatorService calculatorService)
		{
			this.calculatorService = calculatorService;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Total(CalculatorViewModel model)
		{
			var total = calculatorService.Total(model);
            if (!ModelState.IsValid)
			{
				return View(model);
			}
			try
			{
				calculatorService.Total(model);
			}
			catch (Exception)
			{
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your post!");

                return View(model);
            }
			return View(model);
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
