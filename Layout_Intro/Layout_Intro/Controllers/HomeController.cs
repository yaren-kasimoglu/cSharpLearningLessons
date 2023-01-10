using Microsoft.AspNetCore.Mvc;

namespace Layout_Intro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
