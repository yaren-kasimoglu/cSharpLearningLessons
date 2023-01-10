using Microsoft.AspNetCore.Mvc;

namespace Blog_MVC.Controllers
{
	public class AboutUsController : Controller
	{
		public IActionResult AboutUs()
		{
			return View();
		}
	}
}
