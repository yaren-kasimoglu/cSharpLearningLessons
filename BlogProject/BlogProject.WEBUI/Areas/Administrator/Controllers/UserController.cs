using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.WEBUI.Areas.Administrator.Controllers
{
    [Area("Administrator"), Authorize]
    public class USerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
