using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static MVCIntroDemo.Seeding.ProductData;

namespace MVCIntroDemo.Controllers
{
	public class ProductController : Controller
	{
		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
			if (keyword != null)
			{
				var foundProducts = Products.Where(p => p.Name.ToLower() == keyword.ToLower());
				return View(foundProducts);
			}
			return View(Products);
		}
		public IActionResult ById(int id)
		{
			var product = Products.FirstOrDefault(p => p.Id == id);
			if (product == null)
			{
				return BadRequest();
			}
			return View(product);
		}
		public IActionResult AllAsJson()
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
			};
			return Json(Products, options);
		}
		public IActionResult AllAsText()
		{
			var text = string.Empty;
			foreach (var product in Products)
			{
				text += $"Product {product.Id}: {product.Name} - {product.Price}$";
				text += "\r\n";
			}
			return Content(text);
		}
		public IActionResult AllAsTextFile()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var product in Products)
			{
				sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2}$");
			}
			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
			return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
		}
	}
}
